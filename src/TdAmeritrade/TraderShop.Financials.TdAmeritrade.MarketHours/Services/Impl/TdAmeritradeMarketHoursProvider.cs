using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.MarketHours.Models;

namespace TraderShop.Financials.TdAmeritrade.MarketHours.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class TdAmeritradeMarketHoursProvider : ITdAmeritradeMarketHoursProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly HttpClient _httpClient;
        /// <summary>
        /// 
        /// </summary>
        public readonly ITdAmeritradeAuthService _authService;
        /// <summary>
        /// 
        /// </summary>
        public readonly IErrorHandler _errorHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradeMarketHoursProvider(HttpClient httpClient, ITdAmeritradeAuthService authService, IErrorHandler errorHandler)
        {

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
           


            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

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

            var uri = QueryHelpers.AddQueryString(_httpClient?.BaseAddress?.ToString(), query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marketHoursQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
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

            await _errorHandler.CheckQueryErrorsAsync(response);

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
