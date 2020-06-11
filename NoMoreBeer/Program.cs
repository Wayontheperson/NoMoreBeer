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

        static void Main(string[] args)
        {
            List<Price> prices = PriceRepository.Instance.Load(StockName, FromDate); // Price타입 리스트

            //Strategy strategy = new OnePerDayStrategy();
            //Strategy strategy = new SimpleRateStrategy();
            Strategy strategy = new TryTryurmoney();

            strategy.Trade(prices);

            Console.WriteLine(strategy);
            prices[0].Hightvalue.GetRate(prices[prices.Count - 1].Hightvalue);
        }
    }
}
