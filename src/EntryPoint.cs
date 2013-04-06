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
		/// The wait boolean.
		/// </summary>
		static volatile bool wait = false;

		/// <summary>
		/// The mkt generator.
		/// </summary>
		static MarketDataGenerator MarketGenerator;

		/// <summary>
		/// The market data.
		/// </summary>
		static MarketData MarketData = new MarketData();

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		[STAThread]
		public static void Main (string[] args)
		{
			MarketGenerator = new BearMarketGenerator ();

			InitWaitOnKeypressThread ();

			foreach (var price in MarketGenerator.Generate()) {

				WaitOnKeypress ();

				Console.WriteLine(price);
			}
		}

		/// <summary>
		/// Inits the wait on keypress thread.
		/// </summary>
		static void InitWaitOnKeypressThread ()
		{
			ThreadPool.QueueUserWorkItem ((object state) =>  {
				while (!MarketGenerator.Done) {
					if (Console.KeyAvailable) {
						switch (Console.ReadKey ().Key) {
						default:
							wait = false;
							break;
						case ConsoleKey.Spacebar:
							wait = true;
							break;
						}
					}
				}
			});
		}

		/// <summary>
		/// Waits for on keypress if required.
		/// </summary>
		static void WaitOnKeypress ()
		{
			while (wait)
				;
		}
	}
}
