using System;
using Trady.Core.Infrastructure;

namespace Trady.Core
{
    public class CandleWithBuysAndSells : IOhlcbsv
    {
        public CandleWithBuysAndSells(DateTimeOffset dateTime, decimal open, decimal high, decimal low, decimal close, decimal sellsVolume, decimal buysVolume)
        {
            DateTime = dateTime;
            Open = open;
            High = high;
            Low = low;
            Close = close;
            BuysVolume = buysVolume;
            SellsVolume = sellsVolume;
            Volume = sellsVolume + buysVolume;
        }

        public DateTimeOffset DateTime { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }
        public decimal BuysVolume { get; set; }
        public decimal SellsVolume { get; set; }
    }
}
