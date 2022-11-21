using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.PriceHistory.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradePriceHistoryProvider : BaseTdAmeritradeProvider, ITdAmeritradePriceHistoryProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradePriceHistoryProvider(
            HttpClient httpClient,
            ITdAmeritradeAuthService authService,
            IErrorHandler errorHandler) :
            base(
            authService, httpClient, errorHandler)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="priceHistorySpecs"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Candle[]> GetPriceHistory(string symbol, PriceHistorySpecs priceHistorySpecs, CancellationToken cancellationToken)
        {
            var query = new Dictionary<string, string>
            {
                ["periodType"] = priceHistorySpecs.PeriodType.Name,
                ["period"] = priceHistorySpecs.Period.ToString(),
                ["frequencyType"] = priceHistorySpecs.FrequecyType.Name,
                ["frequency"] = priceHistorySpecs.Frequency.ToString(),
                ["endDate"] = priceHistorySpecs.EndDate.ToUnixTimeMilliseconds().ToString(),
                ["startDate"] = priceHistorySpecs.StartDate.ToUnixTimeMilliseconds().ToString()
            };

            var uri = QueryHelpers.AddQueryString($"{baseUri}{symbol}/pricehistory", query);

            var candles = await GetAsync<PriceHistoryRoot>(uri, cancellationToken);

            return candles.Candles;
        }
    }
}