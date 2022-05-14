using TraderShop.Financials.TdAmeritrade.MarketHours.Models;

namespace TraderShop.Financials.TdAmeritrade.MarketHours.Services
{
    public interface ITdAmeritradeMarketHoursProvider
    {
        /// <summary>
        /// Retrieve market hours for specified single market
        /// </summary>
        /// <returns></returns>
        Task<Hour[]> GetHoursForSingleMarket(MarketHoursQuery marketHoursQuery, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieve market hours for specified markets
        /// </summary>
        /// <returns></returns>
        Task<Hour[]> GetHoursForMultipleMarkets(MarketHoursQuery marketHoursQuery, CancellationToken cancellationToken);
    }
}
