using System;

namespace SMART
{
	/// <summary>
	/// Price.
	/// </summary>
	public struct Price : IComparable<Price>, IEquatable<Price>
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
		public double PercentChange 
		{
			get
			{
				return ((Value - (Value - Change)) / (Value - Change)) * 100d;
			}
		}

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents the current <see cref="SMART.Price"/>.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents the current <see cref="SMART.Price"/>.</returns>
        public override string ToString()
        {
            return string.Format("[Price: Value={0}, Change={1}, PercentChange={2}]", Value, Change, PercentChange);
        }
       
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static Price operator+(Price a, Price b)
        {
            // TODO: Examine the value of "Change" for addition & subtraction
            return new Price(a.Value + b.Value, a.Change + b.Change);
        }

        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static Price operator-(Price a, Price b)
        {
            // TODO: Examine the value of "Change" for addition & subtraction
            return new Price(a.Value - b.Value, a.Change - b.Change);
        }

        #region IComparable implementation

        /// <Docs>To be added.</Docs>
        /// <para>Returns the sort order of the current instance compared to the specified object.</para>
        /// <summary>
        /// Compares to.
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="other">Other.</param>
        public int CompareTo(Price other)
        {
            return this.Value.CompareTo(other.Value);
        }

        #endregion

        #region IEquatable implementation

        /// <summary>
        /// Determines whether the specified <see cref="SMART.Price"/> is equal to the current <see cref="SMART.Price"/>.
        /// </summary>
        /// <param name="other">The <see cref="SMART.Price"/> to compare with the current <see cref="SMART.Price"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="SMART.Price"/> is equal to the current <see cref="SMART.Price"/>;
        /// otherwise, <c>false</c>.</returns>
        public bool Equals(Price other)
        {
            return this.Value.Equals(other.Value);
        }

        #endregion
	}
}