using System;
using System.Collections.Generic;
using System.Threading;

namespace SMART.Generators
{
	/// <summary>
	/// Market generator.
	/// </summary>
	public abstract class MarketDataGenerator : IMarketDataGenerator
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SMART.Generators.MarketDataGenerator"/> class.
		/// </summary>
        public MarketDataGenerator ()
		{
			Ticks = 0;
		}

        /// <summary>
        /// Start market data generation for this instance.
        /// </summary>
        public virtual void Start()
        {
            ThreadPool.QueueUserWorkItem(delegate {
                while(!Done)
                {
                    if (DataGeneratedEvent != null)
                    {
                        DataGeneratedEvent(this, new DataGeneratedEventArgs(Generate()));
                        Ticks++;
                    }
                }
            });
        }

		#region IMarketDataGenerator implementation

        /// <summary>
        /// Occurs when data generated event.
        /// </summary>
        public event EventHandler<DataGeneratedEventArgs> DataGeneratedEvent;

		/// <summary>
		/// Generate this instance.
		/// </summary>
        public abstract Price Generate();

		#endregion

		/// <summary>
		/// Gets or sets the ticks.
		/// </summary>
		/// <value>The ticks for this generator</value>
		public long Ticks { get; protected set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="SMART.Generators.MarketDataGenerator"/> is done.
		/// </summary>
		/// <value><c>true</c> if done; otherwise, <c>false</c>.</value>
		public bool Done { get; protected set; }
	}
}

