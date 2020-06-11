using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using NoMoreBeer.Strategies;

namespace NoMoreBeer
{
    public static class Helper
    {
        public static decimal GetRate(this decimal buy, decimal sell)
        {
            return (sell - buy) / buy;
        }
        

        // public static decimal Average(this List<Price> prices,)
        // {
        //     decimal avg = 0;
        //     decimal total = 0;
        //
        //     for (int i = 0; i < 30; i++)
        //     {
        //         avg=p
        //     }
        // }
        
    }
}
