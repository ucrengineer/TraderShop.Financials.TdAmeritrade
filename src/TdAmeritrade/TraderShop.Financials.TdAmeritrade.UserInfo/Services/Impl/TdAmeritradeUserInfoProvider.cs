﻿using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
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
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId });

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
            var uri = new Uri($"{_httpClient?.BaseAddress?.ToString().Split("accounts/")[0]}/userprincipals/streamersubscriptionkeys").ToString();

            if (accountIds != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["symbol"] = string.Join(",", accountIds)
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var subscriptionKey = JsonConvert.DeserializeObject<SubscriptionKey>(responseObject);

            return subscriptionKey;
        }

        public Task<int> GetUserPrincipals(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdatePreferences(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }


    }
}