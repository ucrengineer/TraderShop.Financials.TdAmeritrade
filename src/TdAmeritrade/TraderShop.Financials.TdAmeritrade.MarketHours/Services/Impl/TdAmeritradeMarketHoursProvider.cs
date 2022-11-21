using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.MarketHours.Models;

namespace TraderShop.Financials.TdAmeritrade.MarketHours.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeMarketHoursProvider : BaseTdAmeritradeProvider, ITdAmeritradeMarketHoursProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradeMarketHoursProvider(HttpClient httpClient, ITdAmeritradeAuthService authService, IErrorHandler errorHandler) :
            base(
            authService, httpClient, errorHandler)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="marketHoursQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Hour[]> GetHoursForMultipleMarkets(MarketHoursQuery marketHoursQuery, CancellationToken cancellationToken)
        {
            var query = new Dictionary<string, string>
            {
                ["markets"] = string.Join(",", marketHoursQuery.Markets),
                ["date"] = marketHoursQuery.Date.ToString("yyyy-MM-dd"),
            };

            var uri = QueryHelpers.AddQueryString(baseUri, query);

            var result = await GetAsync<Dictionary<string, Dictionary<string, Hour>>>(uri, cancellationToken);

            var hoursResult = result.Values.First();

            return MapToHours(hoursResult);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="marketHoursQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Hour[]> GetHoursForSingleMarket(MarketHoursQuery marketHoursQuery, CancellationToken cancellationToken)
        {
            var query = new Dictionary<string, string>
            {
                ["date"] = marketHoursQuery.Date.ToString("yyyy-MM-dd"),
            };

            var uri = QueryHelpers.AddQueryString(baseUri, query);

            var result = await GetAsync<Dictionary<string, Dictionary<string, Hour>>>(uri, cancellationToken);

            var hoursResult = result.Values.First();

            return MapToHours(hoursResult);
        }

        private Hour[] MapToHours(Dictionary<string, Hour> hoursDictionary)
        {
            return hoursDictionary.Select(hour =>
                new Hour()
                {
                    Product = hour.Value.Product,
                    ProductName = hour.Value.ProductName,
                    Category = hour.Value.Category,
                    Date = hour.Value.Date,
                    Exchange = hour.Value.Exchange,
                    isOpen = hour.Value.isOpen,
                    MarketType = hour.Value.MarketType ?? string.Empty,
                    SessionHours = hour.Value.SessionHours
                }).ToArray();
        }
    }
}
