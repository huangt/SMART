using System;

namespace SMART.BuySellStrategies
{
    /// <summary>
    /// Buy sell strategy.
    /// </summary>
    public class BuySellStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SMART.BuySellStrategies.BuySellStrategy"/> class.
        /// </summary>
        /// <param name="buySignal">Buy signal.</param>
        /// <param name="sellSignal">Sell signal.</param>
        public BuySellStrategy(Signal buySignal, Signal sellSignal)
        {
            _sellSignal = sellSignal;
            _buySignal = buySignal;
        }

        /// <summary>
        /// Markets the tick.
        /// </summary>
        public virtual void MarketTick(long tick)
        {

        }

        /// <summary>
        /// Occurs when sell signal event.
        /// </summary>
        public event EventHandler<SignalEventArgs> SellSignalEvent;

        /// <summary>
        /// Occurs when buy signal event.
        /// </summary>
        public event EventHandler<SignalEventArgs> BuySignalEvent;

        /// <summary>
        /// The _sell signal.
        /// </summary>
        private readonly Signal _sellSignal;

        /// <summary>
        /// The _buy signal.
        /// </summary>
        private readonly Signal _buySignal;
    }
}

