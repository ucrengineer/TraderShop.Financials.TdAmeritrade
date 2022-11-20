using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.PriceHistory.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITdAmeritradePriceHistoryProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="priceHistorySpecs"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Candle[]> GetPriceHistory(string symbol, PriceHistorySpecs priceHistorySpecs, CancellationToken cancellationToken = default);
    }
}
