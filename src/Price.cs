using System;

namespace SMART
{
	/// <summary>
	/// Price.
	/// </summary>
	public struct Price
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SMART.Price"/> struct.
		/// </summary>
		/// <param name="price">Price.</param>
		/// <param name="change">Change.</param>
		public Price(double price, double change) 
			: this()
		{
			Value = price;
			Change = change;

			// TODO: Compute the percent change automatically.
			PercentChange = 0.0;
		}

		/// <summary>
		/// Gets the price.
		/// </summary>
		/// <value>The price.</value>
		public double Value { get; private set; }

		/// <summary>
		/// Gets the change.
		/// </summary>
		/// <value>The change.</value>
		public double Change { get; private set; }

		/// <summary>
		/// Gets the percent change.
		/// </summary>
		/// <value>The percent change.</value>
		public double PercentChange { get; private set; }
	}
}

