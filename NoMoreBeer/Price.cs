using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoMoreBeer
{
    /// <summary>
    /// 주가
    /// </summary>
    public class Price
    {
        private Price(DateTime date, decimal hightvalue,decimal lowvalue) 
        {
            Date = date;
            Hightvalue = hightvalue;
            LowValue =lowvalue
        }

        

        /// <summary>
        /// 일자
        /// </summary>
        public DateTime Date { get; }
        
        /// <summary>
        /// 주가 (당일 가장 높을때)
        /// </summary>
        public decimal Hightvalue { get; }
        
        /// <summary>
        /// 주가 (당일 가장 낮을때 가격)
        /// </summary>
        public decimal LowValue { get; }
        
        
        /// <summary>
        /// 전일 대비 등락률
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// 문자열을 해석하여 Price 객체를 만든다.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Price Parse(string line)
        {
            try
            {
                string[] tokens = line.Split(',');
                DateTime date = DateTime.Parse(tokens[0]);
                decimal HighValue = decimal.Parse(tokens[2]);
                decimal LowValue = decimal.Parse(tokens[3]);

                return new Price(date, HighValue,LowValue);
            }
            catch
            {
                return null;
            }
        }
    }
}
