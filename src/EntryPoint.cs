using System;
using SMART.Generators;
using System.Threading;
using SMART.BuySellStrategies;

namespace SMART
{
	/// <summary>
	/// Main class.
	/// </summary>
	class MainClass
	{
        /// <summary>
        /// The done.
        /// </summary>
        volatile static bool _done = false;
       
        /// <summary>
        /// Wires the buy sell events.
        /// </summary>
        /// <param name="strategy">Strategy.</param>
        static void WireBuySellEvents(BuySellStrategy strategy)
        {
            // this is where the acount holdings will be updated

            strategy.BuySignalEvent += (object sender, SignalEventArgs e) => 
            {

            };

            strategy.SellSignalEvent += (object sender, SignalEventArgs e) => 
            {

            };
        }

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		[STAThread]
		public static void Main (string[] args)
		{
            // this is here for test only; individual strategies will implement their own.
            var strategy = new BuySellStrategy(
                (long tick, MarketData data) => 
                    {
                           return false;
                    }, 
                (long tick, MarketData data) => 
                    {
                           return false;
                    });

            WireBuySellEvents(strategy);

            var MarketData = new MarketData();
			var MarketGenerator = new RandomMarketDataGenerator();
         
            MarketGenerator.DataGeneratedEvent += (object sender, DataGeneratedEventArgs e) => 
            {
                // force the market tick through the strategy delegates
                strategy.MarketTick(MarketGenerator.Ticks, e.Price);

                Console.WriteLine(e.Price);
                MarketData.Add(e.Price);
                Thread.Sleep(1000);
            };

            MarketGenerator.Start();

            while(!MarketGenerator.Done)
            {
                WaitOnKeypress();
            }
		}

		/// <summary>
		/// Waits for on keypress if required.
		/// </summary>
		static void WaitOnKeypress ()
		{
            if (Console.KeyAvailable) {
                switch (Console.ReadKey ().Key) {
                default:
                    switch(Console.ReadKey().Key) {
                    default:
                        break;
                    }
                    break;
                }
            }
        }
	}
}

