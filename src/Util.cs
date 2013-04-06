using System;

namespace SMART
{
    /// <summary>
    /// Util.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// Initializes the <see cref="SMART.Util"/> class.
        /// </summary>
        static Util()
        {
            Random = new Random();
        }

        /// <summary>
        /// The random.
        /// </summary>
        public static Random Random { get; private set; }

        /// <summary>
        /// Coins the flip.
        /// </summary>
        /// <returns><c>true</c>, if flip was coined, <c>false</c> otherwise.</returns>
        public static bool CoinFlip()
        {
            return Random.Next() % 2 == 0;
        }
    }
}

