using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.UserInfo.Models;

namespace TraderShop.Financials.TdAmeritrade.UserInfo.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeUserInfoProvider : ITdAmeritradeUserInfoProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IErrorHandler _errorHandler;
        private readonly ITdAmeritradeAuthService _authService;

        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        /// <param name="authService"></param>
        public TdAmeritradeUserInfoProvider(HttpClient httpClient, IErrorHandler errorHandler, ITdAmeritradeAuthService authService)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
           

            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        async Task<Preferences> ITdAmeritradeUserInfoProvider.GetPreferences(string accountId, CancellationToken cancellationToken)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/preferences").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var preferences = JsonConvert.DeserializeObject<Preferences>(responseObject);

            if (preferences is null)
                throw new ArgumentNullException(nameof(preferences));

            return preferences;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SubscriptionKey> GetStreamerSubscriptionKeys(string? accountIds, CancellationToken cancellationToken = default)
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

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var subscriptionKey = JsonConvert.DeserializeObject<SubscriptionKey>(responseObject);

            if (subscriptionKey is null)
                throw new ArgumentNullException(nameof(subscriptionKey));

            return subscriptionKey;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UserPrinciple> GetUserPrincipals(string? fields, CancellationToken cancellationToken = default)
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

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var userPrinciple = JsonConvert.DeserializeObject<UserPrinciple>(responseObject);

            if (userPrinciple is null)
                throw new ArgumentNullException(nameof(userPrinciple));

            return userPrinciple;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="preferences"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> UpdatePreferences(string accountId, Preferences preferences, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/preferences").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var preferencesJson = JsonConvert.SerializeObject(preferences);

            var content = new StringContent(preferencesJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
        }
    }
}
