using System;

namespace SMART.Generators
{
    /// <summary>
    /// Random market generator.
    /// </summary>
    public class RandomMarketGenerator : MarketDataGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SMART.Generators.RandomMarketGenerator"/> class.
        /// </summary>
        public RandomMarketGenerator(MarketData marketData)
            : base(marketData)
        {
        }

        /// <summary>
        /// The last price.
        /// </summary>
        double lastPrice = 0;

        /// <summary>
        /// The current price.
        /// </summary>
        double currentPrice = 0;

        /// <summary>
        /// Generate this instance.
        /// </summary>
        public override System.Collections.Generic.IEnumerable<Price> Generate()
        {
            Ticks++;

            lastPrice = currentPrice;

            if (Util.Random.Next() % 2 == 0)
            {
                currentPrice += Util.Random.NextDouble();
            }
            else
            {
                currentPrice -= Util.Random.NextDouble();
            }

            var newPrice = new Price(currentPrice, currentPrice - lastPrice);

            MarketData.Add(newPrice);

            yield return newPrice;
        }
    }
}

