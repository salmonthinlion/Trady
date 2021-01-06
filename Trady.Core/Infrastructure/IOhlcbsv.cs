using System;
using System.Collections.Generic;
using System.Text;

namespace Trady.Core.Infrastructure
{
    /// <summary>
    /// The same as IOhlcv extended by sells and buys volumes
    /// </summary>
    public interface IOhlcbsv:IOhlcv
    {
        decimal BuysVolume { get; set; }
        decimal SellsVolume { get; set; }
    }
}
