using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.PriceHistory.Services.Impl
{
    public class TdAmeritradePriceHistoryProvider : ITdAmeritradePriceHistoryProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;
        private readonly IErrorHandler _errorHandler;
        public TdAmeritradePriceHistoryProvider(HttpClient httpClient, ITdAmeritradeAuthService tdAmeritradeAuthService, IErrorHandler errorHandler)
        {
            _httpClient = httpClient;
            _authService = tdAmeritradeAuthService;
            _errorHandler = errorHandler;
        }

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

            return candles?.Candles;
        }
    }
}