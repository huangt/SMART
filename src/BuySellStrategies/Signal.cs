using System;

namespace SMART.BuySellStrategies
{
    /// <summary>
    /// Buy signal delegate
    /// </summary>
    public delegate bool Signal(long tick, MarketData data);
}