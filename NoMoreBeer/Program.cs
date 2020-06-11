using NoMoreBeer.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace NoMoreBeer
{
    
    class Program
    {
        
        const string StockName = "삼성전자";
        static readonly DateTime FromDate = DateTime.Today.AddYears(-10);    // DateTime.Today.AddYears(-5)<- 5년 전부터
        private static int BuyTiming = 0;
        
        static void Main(string[] args)
        {
            Deposit deposit=new Deposit();
            deposit.DepositMoney(50000000);
            List<Price> prices = PriceRepository.Instance.Load(StockName, FromDate); // Price타입 리스트

            //Strategy strategy = new OnePerDayStrategy();
            //Strategy strategy = new SimpleRateStrategy();
            Strategy strategy = new TryTryurmoney();

            strategy.Trade(prices);

            Console.WriteLine(strategy);
            
        }
    }
}
