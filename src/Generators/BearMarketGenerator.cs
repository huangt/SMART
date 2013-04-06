using System;
using System.Collections.Generic;

namespace SMART.Generators
{
	/// <summary>
	/// Bear market generator.
	/// </summary>
	public class BearMarketGenerator : MarketDataGenerator, IMarketDataGenerator
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SMART.Generators.BearMarketGenerator"/> class.
		/// </summary>
		public BearMarketGenerator ()
			: base()
		{
		}

		#region IMarketDataGenerator implementation

		/// <summary>
		/// Generates a bear market
		/// </summary>
		public IEnumerable<double> Generate ()
		{
			while(!Done)
			{

			}
		}

		#endregion
	}
}

