using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.OptionChains.Models;

namespace TraderShop.Financials.TdAmeritrade.OptionChains.Services.Impl
{
    public class TdAmeritradeOptionChainsProvider : ITdAmeritradeOptionChainsProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IErrorHandler _errorHandler;
        private readonly ITdAmeritradeAuthService _authService;

        public TdAmeritradeOptionChainsProvider(HttpClient httpClient, IErrorHandler errorHandler, ITdAmeritradeAuthService authService)
        {
            _httpClient = httpClient;
            _errorHandler = errorHandler;
            _authService = authService;
        }

        public async Task<OptionChain> GetOptionChain(OptionChainQuery optionQuery, CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var query = new Dictionary<string, string>
            {
                ["symbol"] = optionQuery.Symbol,
                ["contractType"] = optionQuery.ContractType.ToString(),
                ["includeQuotes"] = optionQuery.IncludeQuotes.ToString(),
                ["strategy"] = optionQuery.Strategy.ToString(),
                ["interval"] = optionQuery.Interval.ToString(),
                ["strike"] = optionQuery.Strike.ToString() ?? string.Empty,
                ["strikeCount"] = optionQuery.StrikeCount.ToString() ?? string.Empty,
                ["range"] = optionQuery.Range.ToString(),
                ["fromDate"] = optionQuery.FromDate.ToString("yyyy-MM-dd"),
                ["toDate"] = optionQuery.ToDate.ToString("yyyy-MM-dd"),
                ["volatility"] = optionQuery.Volatility.ToString(),
                ["underlyingPrice"] = optionQuery.UnderlyingPrice.ToString(),
                ["interestRate"] = optionQuery.InterestRate.ToString(),
                ["daysToExpiration"] = optionQuery.DaysToExpiration.ToString(),
                ["expMonth"] = optionQuery.ExpMonth.ToString(),
                ["optionType"] = optionQuery.OptionType.ToString()
            };

            var uri = QueryHelpers.AddQueryString(_httpClient?.BaseAddress?.ToString(), query);

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var optionChain = JsonConvert.DeserializeObject<OptionChain>(responseObject);

            return optionChain;
        }
    }
}
