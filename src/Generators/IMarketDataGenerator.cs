using System;
using System.Collections;
using System.Collections.Generic;

namespace SMART.Generators
{
	/// <summary>
	/// Market data generator.
	/// </summary>
	public interface IMarketDataGenerator
	{
		/// <summary>
		/// Generate a stream of market data. Most implementations will use the <code>yield return</code> mechanism.
		/// </summary>
		Price Generate();

        /// <summary>
        /// Start this instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Occurs when data generated event.
        /// </summary>
        event EventHandler<DataGeneratedEventArgs> DataGeneratedEvent;
	}
}

