using System;
using System.Collections.Generic;
using System.Linq;

namespace NoMoreBeer.Strategies
{    /// <summary>
     /// 1.입금, 2. 한달간 주식 종가 평균구하기, 3. 종가 평균값의 80% 값에 가진돈 전부 매수 4. 샀던 값의 20% 상승시 전부 매매 , 2번을 매매날 이후로 반복
     /// </summary>
    public class TryTryurmoney: Strategy
    {
        public static int BuyDate = 30;
        public static int SellDate = 0;
        protected override void Buy(List<Price> prices)
        {
            decimal avg=prices.Skip(BuyDate).Take(30).Average(x=>x.Value);
            for (BuyDate=SellDate; BuyDate < prices.Count; BuyDate++)
            {
                if (prices[BuyDate].LowValue <= avg*(decimal)0.9) 
                    // 한달간 주식값 평균
                    // 평균보다 20% 값 떨어지면 구매
                {
                    BuyAll(prices);
                    break;
                }
            }
        }
        
        //linQ 평균구하고  skip(n)<- n까지 무시 take(n)<- n부터 자료가져와 명령어로 구간 값 정한다.

        protected override void Sell(List<Price> prices)    // 구매한 주식이 20% 상승시 판매
        {
            for (SellDate = BuyDate; SellDate < prices.Count; SellDate++)
            {
                if (prices[SellDate].Hightvalue > (prices[BuyDate].Hightvalue) * (decimal) (1.1))
                {
                    Trade trade=new Trade();
                    SellAll(trade, prices);
                    break;
                }
            }
        }
    }
} 