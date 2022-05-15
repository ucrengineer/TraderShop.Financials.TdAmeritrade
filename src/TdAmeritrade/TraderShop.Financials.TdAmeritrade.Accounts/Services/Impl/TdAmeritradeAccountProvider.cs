using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Accounts.Models;

namespace TraderShop.Financials.TdAmeritrade.Accounts.Services.Impl
{
    public class TdAmeritradeAccountProvider : ITdAmeritradeAccountProvider
    {
        private readonly ITdAmeritradeAuthService _authService;
        private readonly HttpClient _httpClient;
        private readonly IErrorHandler _errorHandler;
        public TdAmeritradeAccountProvider(ITdAmeritradeAuthService authService, HttpClient httpClient, IErrorHandler errorHandler)
        {
            _authService = authService;
            _httpClient = httpClient;
            _errorHandler = errorHandler;
        }
        public async Task<SecuritiesAccount[]> GetAccounts(string[]? fields, CancellationToken cancellationToken)
        {

            var uri = new Uri($"{_httpClient.BaseAddress}").ToString();

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["fields"] = String.Join(",", fields),
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var securitesAccountRoots = JsonConvert.DeserializeObject<SecuritiesAccountRoot[]>(responseObject);

            var securitiesAccounts = new SecuritiesAccount[securitesAccountRoots.Length];

            for (int i = 0; i < securitesAccountRoots.Length; i++)
            {
                securitiesAccounts[i] = securitesAccountRoots[i].SecuritiesAccount;
            }

            return securitiesAccounts;

        }
        public async Task<SecuritiesAccount> GetAccount(string accountId, string[]? fields, CancellationToken cancellationToken)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId }, new string[]{"accountId"});

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}").ToString();

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["fields"] = String.Join(",", fields),
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var securitesAccount = JsonConvert.DeserializeObject<SecuritiesAccountRoot>(responseObject);

            return securitesAccount?.SecuritiesAccount;
        }
    }
}
