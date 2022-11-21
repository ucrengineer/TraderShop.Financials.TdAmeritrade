using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.UserInfo.Models;

namespace TraderShop.Financials.TdAmeritrade.UserInfo.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeUserInfoProvider : BaseTdAmeritradeProvider, ITdAmeritradeUserInfoProvider
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        /// <param name="authService"></param>
        public TdAmeritradeUserInfoProvider(
            HttpClient httpClient,
            IErrorHandler errorHandler,
            ITdAmeritradeAuthService authService)
            : base(authService,
                  httpClient,
                  errorHandler)
        { }

        async Task<Preferences> ITdAmeritradeUserInfoProvider.GetPreferences(string accountId, CancellationToken cancellationToken)
        {
            var uri = $"{baseUri}{accountId}/preferences";

            var preferences = await GetAsync<Preferences>(uri, cancellationToken);

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

            var uri = $"{baseUri.Split("accounts/")[0]}/userprincipals/streamersubscriptionkeys";

            if (accountIds != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["symbol"] = string.Join(",", accountIds)
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            var subscriptionKey = await GetAsync<SubscriptionKey>(uri, cancellationToken);

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
            var uri = $"{baseUri.Split("accounts/")[0]}/userprincipals";

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["symbol"] = string.Join(",", fields)
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            var userPrinciple = await GetAsync<UserPrinciple>(uri, cancellationToken);

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
            var uri = $"{baseUri}{accountId}/preferences";

            return await PutAsync<Preferences>(uri, preferences, cancellationToken);
        }
    }
}
