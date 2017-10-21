using System;
using System.Collections.Generic;
using Trady.Analysis.Infrastructure;
using Trady.Core;
using Trady.Core.Infrastructure;

namespace Trady.Analysis
{
    public class SimpleRuleExecutor : RuleExecutorBase<IOhlcvData, IndexedCandle, IndexedCandle>
    {
        public SimpleRuleExecutor(IAnalyzeContext<IOhlcvData> context, Predicate<IndexedCandle> rule)
            : base((l, i) => l, context, new Predicate<IndexedCandle>[] { rule })
        {
        }

        public override Func<IEnumerable<IOhlcvData>, int, IndexedCandle> IndexedObjectConstructor
            => (l, i) => new IndexedCandle(l, i);
    }
}