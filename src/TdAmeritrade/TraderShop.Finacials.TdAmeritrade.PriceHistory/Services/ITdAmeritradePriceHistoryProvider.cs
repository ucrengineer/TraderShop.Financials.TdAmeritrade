using TraderShop.Finacials.TdAmeritrade.PriceHistory.Models;

namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.Services
{
    public interface ITdAmeritradePriceHistoryProvider
    {
        Task<Candle[]> GetPriceHistory(PriceHistorySpecs priceHistorySpecs);
    }
}
