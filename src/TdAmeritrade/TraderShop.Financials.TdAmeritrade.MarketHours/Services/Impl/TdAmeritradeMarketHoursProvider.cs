using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.MarketHours.Models;

namespace TraderShop.Financials.TdAmeritrade.MarketHours.Services.Impl
{
    public class TdAmeritradeMarketHoursProvider : ITdAmeritradeMarketHoursProvider
    {
        public readonly HttpClient _httpClient;
        public readonly ITdAmeritradeAuthService _authService;
        public readonly IErrorHandler _errorHandler;

        public TdAmeritradeMarketHoursProvider(HttpClient httpClient, ITdAmeritradeAuthService authService, IErrorHandler errorHandler)
        {
            _httpClient = httpClient;
            _authService = authService;
            _errorHandler = errorHandler;
        }

        public async Task<Hour[]> GetHoursForMultipleMarkets(MarketHoursQuery marketHoursQuery, CancellationToken cancellationToken)
        {
            var query = new Dictionary<string, string>
            {
                ["markets"] = string.Join(",", marketHoursQuery.Markets),
                ["date"] = marketHoursQuery.Date.ToString("yyyy-MM-dd"),
            };

            var uri = QueryHelpers.AddQueryString(_httpClient?.BaseAddress?.ToString(), query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var hoursResult = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Hour>>>(responseObject)?.Values.FirstOrDefault();

            var i = 0; var hours = new Hour[hoursResult.Count];

            foreach (var hour in hoursResult)
            {
                hours[i] = new Hour()
                {
                    Product = hour.Value.Product,
                    ProductName = hour.Value.ProductName,
                    Category = hour.Value.Category,
                    Date = hour.Value.Date,
                    Exchange = hour.Value.Exchange,
                    isOpen = hour.Value.isOpen,
                    MarketType = hour.Value.MarketType ?? string.Empty,
                };
                hours[i].SessionHours = hour.Value.SessionHours;
                i++;
            }

            return hours;
        }

        public async Task<Hour[]> GetHoursForSingleMarket(MarketHoursQuery marketHoursQuery, CancellationToken cancellationToken)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{marketHoursQuery.Markets.FirstOrDefault()}/hours").ToString();

            var query = new Dictionary<string, string>
            {
                ["date"] = marketHoursQuery.Date.ToString("yyyy-MM-dd"),
            };

            uri = QueryHelpers.AddQueryString(uri, query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var hoursResult = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, Hour>>>(responseObject)?.Values.FirstOrDefault();

            var i = 0; var hours = new Hour[hoursResult.Count];

            foreach (var hour in hoursResult)
            {
                hours[i] = new Hour()
                {
                    Product = hour.Value.Product,
                    ProductName = hour.Value.ProductName,
                    Category = hour.Value.Category,
                    Date = hour.Value.Date,
                    Exchange = hour.Value.Exchange,
                    isOpen = hour.Value.isOpen,
                    MarketType = hour.Value.MarketType ?? string.Empty,
                };
                hours[i].SessionHours = hour.Value.SessionHours;
                i++;
            }

            return hours;
        }
    }
}
