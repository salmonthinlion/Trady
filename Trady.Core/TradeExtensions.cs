using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trady.Core.Infrastructure;
using Trady.Core.Period;

namespace Trady.Core
{
    public static class TradeExtensions
    {      
        public static IReadOnlyList<IOhlcbsv> TransformToCandles<TTargetPeriod>(this IEnumerable<ITickTrade> trades)           
           where TTargetPeriod : IPeriod
        {
            var outputCandles = new List<IOhlcbsv>();

            if (!trades.Any())
                return outputCandles;

            var periodInstance = Activator.CreateInstance<TTargetPeriod>();

            // To prevent lazy evaluated when compute
            var orderedTrades = trades.OrderBy(c => c.DateTime).ToList();

            var periodStartTime = orderedTrades[0].DateTime;
            var periodEndTime = periodInstance.NextTimestamp(periodStartTime);

            var tempTrades = new List<ITickTrade>();
            for (int i = 0; i < orderedTrades.Count; i++)
            {
                var indexTime = orderedTrades[i].DateTime;
                if (indexTime >= periodEndTime)
                {
                    periodStartTime = periodEndTime;
                    periodEndTime = periodInstance.NextTimestamp(periodStartTime);

                    AddComputedCandleToOutput(outputCandles, tempTrades);
                    tempTrades = new List<ITickTrade>();
                }
                tempTrades.Add(orderedTrades[i]);
            }

            if (tempTrades.Any())
                AddComputedCandleToOutput(outputCandles, tempTrades);

            return outputCandles;
        }
        private static void AddComputedCandleToOutput(List<IOhlcbsv> outputCandlesFromTrades, List<ITickTrade> tempTrades)
        {
            var computedCandle = ComputeCandles(tempTrades);
            if (computedCandle != null)
                outputCandlesFromTrades.Add(computedCandle);
        }
        private static IOhlcbsv ComputeCandles(IEnumerable<ITickTrade> trades)
        {
            if (!trades.Any())
                return null;

            var dateTime = trades.First().DateTime;
            var open = trades.First().Price;
            var high = trades.Max(trade => trade.Price);
            var low = trades.Min(trade => trade.Price);
            var close = trades.Last().Price;
            var sells = 0m;
            var buys = 0m;

            foreach(var trade in trades)
            {
                if (trade.IsSell)
                {
                    sells += trade.Volume;
                }
                else
                {
                    buys += trade.Volume;
                }
            }          
            return new CandleWithBuysAndSells(dateTime, open, high, low, close, sells,buys);
        }
    }
}
