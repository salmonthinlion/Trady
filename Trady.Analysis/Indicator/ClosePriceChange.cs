using System;
using System.Collections.Generic;
using Trady.Core;
using Trady.Core.Infrastructure;

namespace Trady.Analysis.Indicator
{
	public class ClosePriceChange : Difference<IOhlcvData, AnalyzableTick<decimal?>>
	{
        public ClosePriceChange(IEnumerable<IOhlcvData> inputs, int numberOfDays = 1)
			: base(inputs, i => i.Close, numberOfDays)
		{
		}
	}
}
