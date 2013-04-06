using System;

namespace SMART.BuySellStrategies
{
	public delegate bool BuySignal(long tick, MarketData data);

	/// <summary>
	/// I buy sell strategy.
	/// </summary>
	public interface IBuySellStrategy
	{
		bool BuyTrigger(BuySignal d);

	}
}

