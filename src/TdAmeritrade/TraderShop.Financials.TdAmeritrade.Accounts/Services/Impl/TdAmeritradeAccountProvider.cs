using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Accounts.Models;

namespace TraderShop.Financials.TdAmeritrade.Accounts.Services.Impl
{
    public class TdAmeritradeAccountProvider : ITdAmeritradeAccountProvider
    {
        private readonly ITdAmeritradeAuthService _authService;
        private readonly HttpClient _httpClient;
        private TdAmeritradeOptions _tdAmeritradeOptions;


        public TdAmeritradeAccountProvider(ITdAmeritradeAuthService authService, HttpClient httpClient, IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions)
        {
            _authService = authService;
            _httpClient = httpClient;
            _tdAmeritradeOptions = tdAmeritradeOptions.CurrentValue;
            tdAmeritradeOptions.OnChange(x => _tdAmeritradeOptions = x);
        }

        public async Task<SecuritiesAccount> GetAccount(string[]? fields)
        {
            await _authService.SetAccessToken();

            string? uri = default;

            _httpClient.BaseAddress = new Uri($"{_httpClient.BaseAddress}{_tdAmeritradeOptions.account_number}");

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["fields"] = String.Join(",", fields),
                };

                uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);
            }


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tdAmeritradeOptions.access_token);

            var response = await _httpClient.GetAsync(uri ?? _httpClient?.BaseAddress?.ToString());

            var responseObject = await response.Content.ReadAsStringAsync();

            var securitesAccount = JsonConvert.DeserializeObject<SecuritiesAccountRoot>(responseObject);

            return securitesAccount?.SecuritiesAccount;
        }
    }
}
