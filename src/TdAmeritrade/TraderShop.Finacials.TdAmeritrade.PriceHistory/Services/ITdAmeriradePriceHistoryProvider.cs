using TraderShop.Finacials.TdAmeritrade.PriceHistory.Models;

namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.Services
{
    public interface ITdAmeriradePriceHistoryProvider
    {
        Task<Candle[]> GetPriceHistory(PriceHistorySpecs priceHistorySpecs);
    }
}
