using System;

namespace SMART.BuySellStrategies
{
    /// <summary>
    /// Signal event arguments.
    /// </summary>
    public class SignalEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SMART.BuySellStrategies.SignalEventArgs"/> class.
        /// </summary>
        /// <param name="p">P.</param>
        public SignalEventArgs(Price price)
        {
            price = Price;
        }

        /// <summary>
        /// Sets the price.
        /// </summary>
        /// <value>The price.</value>
        public Price Price { get; protected set; }
    }
}

