using System;

namespace SMART.BuySellStrategies
{
	/// <summary>
	/// Buy signal delegate
	/// </summary>
	public delegate bool BuySignal(long tick, MarketData data);

	/// <summary>
	/// Sell signal delegate
	/// </summary>
	public delegate bool SellSignal(long tick, MarketData data);

	/// <summary>
	/// I buy sell strategy.
	/// </summary>
	public interface IBuySellStrategy
	{
		bool BuyTrigger(BuySignal d);
		bool SellTrigger(SellSignal d);
	}
}