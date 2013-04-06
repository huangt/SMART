using System;
using SMART.Generators;
using System.Threading;

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
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		[STAThread]
		public static void Main (string[] args)
		{
            MarketData MarketData = new MarketData();
			MarketDataGenerator MarketGenerator = new RandomMarketDataGenerator();

            MarketGenerator.DataGeneratedEvent += (object sender, DataGeneratedEventArgs e) => 
            {
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

