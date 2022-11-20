using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.PriceHistory.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradePriceHistoryProvider : ITdAmeritradePriceHistoryProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;
        private readonly IErrorHandler _errorHandler;
        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradePriceHistoryProvider(
            HttpClient httpClient,
            ITdAmeritradeAuthService authService,
            IErrorHandler errorHandler)
        {

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

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

            var uri = QueryHelpers.AddQueryString($"{_httpClient.BaseAddress}{symbol}/pricehistory", query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var candles = JsonConvert.DeserializeObject<PriceHistoryRoot>(responseObject);

            if (candles is null)
                throw new ArgumentNullException(nameof(PriceHistoryRoot));

            return candles.Candles;
        }
    }
}