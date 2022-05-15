using TraderShop.Financials.TdAmeritrade.UserInfo.Models;

namespace TraderShop.Financials.TdAmeritrade.UserInfo.Services
{
    public interface ITdAmeritradeUserInfoProvider
    {
        /// <summary>
        /// Preferences for a specific account.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Preferences> GetPreferences(string accountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// SubscriptionKey for provided accounts or default accounts.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SubscriptionKey> GetStreamerSubscriptionKeys(string[]? accountIds = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// User Principal details.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> GetUserPrincipals(CancellationToken cancellationToken = default);
        /// <summary>
        /// <para>
        /// Update preferences for a specific account. Please note that the directOptionsRouting and directEquityRouting values cannot be modified via this operation.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> UpdatePreferences(CancellationToken cancellationToken = default);

    }
}
