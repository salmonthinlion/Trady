using System.Collections.Generic;

namespace Trady.Core.Infrastructure
{
    public interface IIndexedOhlcvData : IOhlcvData, IIndexedObject<IOhlcvData>
    {
        new IEnumerable<IOhlcvData> BackingList { get; }

        new IIndexedOhlcvData Prev { get; }

        new IIndexedOhlcvData Next { get; }

        new IIndexedOhlcvData Underlying { get; }

        new IAnalyzeContext<IOhlcvData> Context { get; set; }

        TAnalyzable Get<TAnalyzable>(params object[] @params)
            where TAnalyzable : IAnalyzable;
    }
}