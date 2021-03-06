﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Schema;

namespace NoMoreBeer.Strategies
{
    public abstract class Strategy
    {
        protected Strategy()
        {
            Trades = new List<Trade>();
        }

        protected List<Trade> Trades { get; }

        public decimal BuySum { get; private set; }
        public decimal SellSum { get; private set; }
        public decimal Rate { get; private set; }

        public override string ToString()
        {
            StringWriter writer = new StringWriter();
            foreach (var trade in Trades)
            {
                writer.WriteLine(trade);
            }

            writer.WriteLine($"{SellSum:N0} - {BuySum:N0} = {SellSum - BuySum:N0} ({Rate:P2})");

            return writer.ToString();
        }

        internal void Trade(List<Price> prices)
        {
            Buy(prices);

            Sell(prices);

            // 총매수액 등을 구한다.
            BuySum = Trades.Sum(x => x.BuyValue);
            SellSum = Trades.Sum(x => x.SellValue);
            Rate = BuySum.GetRate(SellSum);
           
        }

        /// <summary>
        /// 조건에 맞는 주식을 매수한다.
        /// </summary>
        /// <param name="prices"></param>
        protected abstract void Buy(List<Price> prices);

        /// <summary>
        /// 마지막 날의 가격으로 매수한 주식을 모두 매도한다. (재정의 가능)
        /// </summary>
        /// <param name="prices"></param>
        protected virtual void Sell(List<Price> prices)
        {
            Price lastPrice = prices[prices.Count - 1];
            

            foreach (var trade in Trades)
            {
                SellOne(trade, lastPrice);
            }

        }

        protected void BuyOne(Price price)
        {
            Trade trade = new Trade();
            trade.BuyOn = price.Date;
            trade.BuyValue = price.LowValue;

            Trades.Add(trade);
        }

        protected void BuyAll(List<Price> prices)
        {
            Deposit deposit=new Deposit();
            Trade trade=new Trade();
            StockVolume stock=new StockVolume();
            decimal total = 0;
            
            while (total< deposit.money)
            {
                total+=prices[TryTryurmoney.BuyDate].LowValue;
                stock.NumberOfVolume();
            }
            trade.BuyOn = prices[TryTryurmoney.BuyDate].Date;
            trade.BuyValue = total;
        }

        protected void SellOne(Trade trade, Price price)
        {
            trade.SellValue = price.Hightvalue;
            trade.SellOn = price.Date;
            trade.Rate = trade.BuyValue.GetRate(trade.SellValue);
        }

        protected void SellAll(Trade trade, List<Price> prices)
        {
            trade.SellOn = prices[TryTryurmoney.SellDate].Date;
            trade.Rate = trade.BuyValue.GetRate(trade.SellValue);
            trade.SellValue =prices[TryTryurmoney.SellDate].Hightvalue*(StockVolume.volume) ;
            StockVolume.VolumeClear();
        }
    }
}