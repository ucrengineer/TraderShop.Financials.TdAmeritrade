using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Accounts.Models;

namespace TraderShop.Financials.TdAmeritrade.Accounts.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeAccountProvider : BaseTdAmeritradeProvider, ITdAmeritradeAccountProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradeAccountProvider(
            ITdAmeritradeAuthService authService,
            HttpClient httpClient,
            IErrorHandler errorHandler) :
            base(authService,
                httpClient,
                errorHandler)
        { }
        /// <summary>
        ///
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SecuritiesAccount[]> GetAccounts(string? fields, CancellationToken cancellationToken)
        {
            var uri = baseUri;

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["fields"] = fields,
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            var securitesAccountRoots = await GetAsync<SecuritiesAccountRoot[]>(uri, cancellationToken);

            var securitiesAccounts = new SecuritiesAccount[securitesAccountRoots.Length];

            for (int i = 0; i < securitesAccountRoots.Length; i++)
            {
                securitiesAccounts[i] = securitesAccountRoots[i].SecuritiesAccount;
            }

            return securitiesAccounts;

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="fields"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SecuritiesAccount> GetAccount(string accountId, string? fields, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new Exception("AccountId cannot be a empty string");
            }

            var uri = baseUri + accountId;

            if (fields != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["fields"] = fields,
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            var securitesAccountRoot = await GetAsync<SecuritiesAccountRoot>(uri, cancellationToken);

            return securitesAccountRoot.SecuritiesAccount;
        }
    }
}
