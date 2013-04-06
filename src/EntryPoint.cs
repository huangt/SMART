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
		static volatile bool wait = false;

		/// <summary>
		/// The mkt generator.
		/// </summary>
		static MarketDataGenerator mktGenerator;

		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		[STAThread]
		public static void Main (string[] args)
		{
			mktGenerator = new BearMarketGenerator ();

			ThreadPool.QueueUserWorkItem ((object state) => {
				while (!mktGenerator.Done) {
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



			foreach (var price in mktGenerator.Generate()) {
				while (wait)
					;
				Console.WriteLine(price);
			}
		}
	}
}
