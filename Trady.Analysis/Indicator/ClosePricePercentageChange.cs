using System.Collections.Generic;
using Trady.Core;
using Trady.Core.Infrastructure;

namespace Trady.Analysis.Indicator
{
    public class ClosePricePercentageChange : PercentageDifference<IOhlcvData, AnalyzableTick<decimal?>>
    {
        public ClosePricePercentageChange(IEnumerable<IOhlcvData> inputs, int numberOfDays = 1)
            : base(inputs, i => i.Close, numberOfDays)
        {
        }
    }
}