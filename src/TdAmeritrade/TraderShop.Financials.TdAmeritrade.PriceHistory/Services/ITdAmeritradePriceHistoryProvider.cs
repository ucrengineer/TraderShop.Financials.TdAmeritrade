using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.PriceHistory.Services
{
    public interface ITdAmeritradePriceHistoryProvider
    {
        Task<Candle[]> GetPriceHistory(string symbol, PriceHistorySpecs priceHistorySpecs, CancellationToken cancellationToken = default);
    }
}
