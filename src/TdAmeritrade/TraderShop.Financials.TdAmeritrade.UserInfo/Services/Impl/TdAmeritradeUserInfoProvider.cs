using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.UserInfo.Models;

namespace TraderShop.Financials.TdAmeritrade.UserInfo.Services.Impl
{
    public class TdAmeritradeUserInfoProvider : ITdAmeritradeUserInfoProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IErrorHandler _errorHandler;
        private readonly ITdAmeritradeAuthService _authService;

        public TdAmeritradeUserInfoProvider(HttpClient httpClient, IErrorHandler errorHandler, ITdAmeritradeAuthService authService)
        {
            _httpClient = httpClient;
            _errorHandler = errorHandler;
            _authService = authService;
        }


        async Task<Preferences> ITdAmeritradeUserInfoProvider.GetPreferences(string accountId, CancellationToken cancellationToken)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId }, new string[] { "accountId" });

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/preferences").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var preferences = JsonConvert.DeserializeObject<Preferences>(responseObject);

            return preferences;
        }

        public async Task<SubscriptionKey> GetStreamerSubscriptionKeys(string[]? accountIds, CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var uri = new Uri($"{_httpClient?.BaseAddress?.ToString().Split("accounts/")[0]}/userprincipals/streamersubscriptionkeys").ToString();

            if (accountIds != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["symbol"] = string.Join(",", accountIds)
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var subscriptionKey = JsonConvert.DeserializeObject<SubscriptionKey>(responseObject);

            return subscriptionKey;
        }

        public async Task<UserPrinciple> GetUserPrincipals(string[]? fields, CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var uri = new Uri($"{_httpClient?.BaseAddress?.ToString().Split("accounts/")[0]}/userprincipals").ToString();

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["symbol"] = string.Join(",", fields)
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var userPrinciple = JsonConvert.DeserializeObject<UserPrinciple>(responseObject);

            return userPrinciple;
        }

        public async Task<int> UpdatePreferences(string accountId, Preferences preferences, CancellationToken cancellationToken = default)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId }, new string[] { "accountId" });

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/preferences").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var preferencesJson = JsonConvert.SerializeObject(preferences);

            var content = new StringContent(preferencesJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content, cancellationToken);

            response.EnsureSuccessStatusCode();

            return 0;
        }


    }
}
