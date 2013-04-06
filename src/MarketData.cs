using System;
using System.Collections.Generic;

namespace SMART
{
	/// <summary>
	/// MarketData
	/// </summary>
	public class MarketData : List<Price>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SMART.MarketData.MarketData"/> class.
		/// </summary>
		/// <param name="initialCapacity">Initial capacity.</param>
		public MarketData (int initialCapacity)
		: base(initialCapacity) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SMART.MarketData.MarketData"/> class.
		/// </summary>
		public MarketData()
		: base() { }
	}
}

