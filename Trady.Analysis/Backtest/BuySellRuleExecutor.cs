using System;
using System.Collections.Generic;
using Trady.Analysis.Infrastructure;
using Trady.Core;
using Trady.Core.Infrastructure;

namespace Trady.Analysis.Backtest
{
    public class BuySellRuleExecutor : RuleExecutorBase<IOhlcvData, IndexedCandle, (TransactionType, IndexedCandle)>
    {
        public BuySellRuleExecutor(
            Func<IndexedCandle, int, (TransactionType, IndexedCandle)> outputFunc, 
            IAnalyzeContext<IOhlcvData> context, 
            Predicate<IndexedCandle> buyRule, 
            Predicate<IndexedCandle> sellRule)
            : base(outputFunc, context, new Predicate<IndexedCandle>[] { buyRule, sellRule })
        {
        }

        public override Func<IEnumerable<IOhlcvData>, int, IndexedCandle> IndexedObjectConstructor
            => (l, i) => new IndexedCandle(l, i);
    }
}