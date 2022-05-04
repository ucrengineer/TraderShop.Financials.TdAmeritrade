using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Finacials.TdAmeritrade.PriceHistory.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;

namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.Services.Impl
{
    public class TdAmeritradePriceHistoryProvider : ITdAmeritradePriceHistoryProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;
        private TdAmeritradeOptions _tdAmeritradeOptions;
        public TdAmeritradePriceHistoryProvider(HttpClient httpClient, ITdAmeritradeAuthService tdAmeritradeAuthService, IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions)
        {
            _httpClient = httpClient;
            _authService = tdAmeritradeAuthService;
            _tdAmeritradeOptions = tdAmeritradeOptions.CurrentValue;
            tdAmeritradeOptions.OnChange(x => _tdAmeritradeOptions = x);
        }

        public async Task<Candle[]> GetPriceHistory(PriceHistorySpecs priceHistorySpecs)
        {
            //await _authService.SetAccessToken();
            _httpClient.BaseAddress = new Uri($"{_httpClient.BaseAddress}{priceHistorySpecs.Symbol}/pricehistory");

            var query = new Dictionary<string, string>
            {
                ["periodType"] = priceHistorySpecs.PeriodType.ToString(),
                ["period"] = priceHistorySpecs.Period.ToString(),
                ["frequencyType"] = priceHistorySpecs.FrequecyType.ToString(),
                ["frequency"] = priceHistorySpecs.Frequency.ToString(),
                ["endDate"] = priceHistorySpecs.EndDate.ToUnixTimeMilliseconds().ToString(),
                ["startDate"] = priceHistorySpecs.StartDate.ToUnixTimeMilliseconds().ToString()

            };

            var uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri);

            var responseObject = await response.Content.ReadAsStringAsync();

            var candles = JsonConvert.DeserializeObject<PriceHistoryRoot>(responseObject);

            return candles?.Candles;
        }

    }
}

