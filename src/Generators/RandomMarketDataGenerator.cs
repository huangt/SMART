using System;

namespace SMART.Generators
{
    /// <summary>
    /// Random market data generator.
    /// </summary>
    public class RandomMarketDataGenerator : MarketDataGenerator
    {
        public RandomMarketDataGenerator()
        {
            currentPrice = 0;
            previousPrice = 0;
        }

        /// <summary>
        /// The current price.
        /// </summary>
        private double currentPrice;

        /// <summary>
        /// The previous price.
        /// </summary>
        private double previousPrice;

        /// <summary>
        /// Generate this instance.
        /// </summary>
        public override Price Generate()
        {
            previousPrice = currentPrice;

            if (Util.CoinFlip())
            {
                currentPrice += Util.Random.NextDouble();
            }
            else
            {
                currentPrice -= Util.Random.NextDouble();
            }

            return new Price(currentPrice, previousPrice);
        }
    }
}

