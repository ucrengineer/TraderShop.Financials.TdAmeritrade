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
        public async Task<SecuritiesAccount[]> GetAccounts(string[]? fields)
        {
            await _authService.SetAccessToken();

            var uri = new Uri($"{_httpClient.BaseAddress}").ToString();

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["fields"] = String.Join(",", fields),
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tdAmeritradeOptions.access_token);

            var response = await _httpClient.GetAsync(uri);

            var responseObject = await response.Content.ReadAsStringAsync();

            var securitesAccountRoots = JsonConvert.DeserializeObject<SecuritiesAccountRoot[]>(responseObject);

            var securitiesAccounts = new SecuritiesAccount[securitesAccountRoots.Length];

            for (int i = 0; i < securitesAccountRoots.Length; i++)
            {
                securitiesAccounts[i] = securitesAccountRoots[i].SecuritiesAccount;
            }

            return securitiesAccounts;

        }
        public async Task<SecuritiesAccount> GetAccount(string accountNumber, string[]? fields)
        {
            await _authService.SetAccessToken();

            var uri = new Uri($"{_httpClient.BaseAddress}{accountNumber}").ToString();

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["fields"] = String.Join(",", fields),
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tdAmeritradeOptions.access_token);

            var response = await _httpClient.GetAsync(uri);

            var responseObject = await response.Content.ReadAsStringAsync();

            var securitesAccount = JsonConvert.DeserializeObject<SecuritiesAccountRoot>(responseObject);

            return securitesAccount?.SecuritiesAccount;
        }
    }
}
