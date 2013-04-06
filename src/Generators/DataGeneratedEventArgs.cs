using System;

namespace SMART.Generators
{
    /// <summary>
    /// Data generated event arguments.
    /// </summary>
    public class DataGeneratedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SMART.Generators.DataGeneratedEventArgs"/> class.
        /// </summary>
        public DataGeneratedEventArgs(Price price)
        {
            Price = price;
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public Price Price { get; private set; }
    }
}

