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
        /// <para>
        /// A comma separated String which allows one to specify additional fields to return. None of these fields are returned by default.
        /// Possible values in this String can be:
        /// <list type="bullet">
        /// <item><description>streamerSubscriptionKeys</description></item>
        /// <item><description>streamerConnectionInfo</description></item>
        /// <item><description>preferences</description></item>
        /// <item><description>surrogateIds</description></item></list>
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<UserPrinciple> GetUserPrincipals(string[]? fields = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// <para>
        /// Update preferences for a specific account. Please note that the directOptionsRouting and directEquityRouting values cannot be modified via this operation.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> UpdatePreferences(string accountId, Preferences preferences, CancellationToken cancellationToken = default);

    }
}
