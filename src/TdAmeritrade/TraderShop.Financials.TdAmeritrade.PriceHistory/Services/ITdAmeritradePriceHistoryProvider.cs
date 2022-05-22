using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;

namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.Services
{
    public interface ITdAmeritradePriceHistoryProvider
    {
        Task<Candle[]> GetPriceHistory(PriceHistorySpecs priceHistorySpecs, CancellationToken cancellationToken = default);
    }
}
