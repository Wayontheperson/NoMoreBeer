using System;
using System.Collections.Generic;

namespace NoMoreBeer.Strategies
{
    public class TryTryurmoney: Strategy
    {
        protected override void Buy(List<Price> prices)
        {
            for (int i = 1; i < prices.Count; i++)
            {
                if (prices[i].Hightvalue.Average()) 
                    // 한달간 주식값 평균
                    // 평균보다 20% 값 떨어지면 구매
                    
                {
                    BuyOne(prices[i]); 
                }
                
            }
        }

        protected override void Sell(List<Price> prices)    // 구매한 주식이 20% 상승시 판매
        {
            for (int i = 2; i < prices.Count; i++)
            {
                if (.Value > (prices[i - 1].Hightvalue) * (decimal) (1.2))
                {
                    Trade trade=new Trade();
                    SellOne(trade, prices[i]);
                }
            }
        }
    }
}