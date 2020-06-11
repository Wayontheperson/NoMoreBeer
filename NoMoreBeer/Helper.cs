using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoMoreBeer.Strategies;

namespace NoMoreBeer
{
    public static class Helper
    {
        public static decimal GetRate(this decimal buy, decimal sell)
        {
            return (sell - buy) / buy;
        }
        public static decimal PriceCurve(this decimal buy, decimal sell)
        {
            return (sell - buy) / buy;
        }
        
    }
}
