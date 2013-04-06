using System;

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
		/// Gets or sets the ticks.
		/// </summary>
		/// <value>The ticks for this generator</value>
		public long Ticks { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="SMART.Generators.MarketDataGenerator"/> is done.
		/// </summary>
		/// <value><c>true</c> if done; otherwise, <c>false</c>.</value>
		public bool Done { get; protected set; }
	}
}

