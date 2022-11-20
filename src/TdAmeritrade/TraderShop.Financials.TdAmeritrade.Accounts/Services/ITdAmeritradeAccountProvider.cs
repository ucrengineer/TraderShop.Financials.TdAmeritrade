using TraderShop.Financials.TdAmeritrade.Accounts.Models;

namespace TraderShop.Financials.TdAmeritrade.Accounts.Services
{
    /// <summary>
    /// Currently only supports balances
    /// </summary>
    public interface ITdAmeritradeAccountProvider
    {
        /// <summary>
        /// Balances displayed by default, additional fields can be added here by adding positions or orders
        /// Example: fields=positions,orders
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="fields"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SecuritiesAccount> GetAccount(string accountId, string? fields = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Balances displayed by default, additional fields can be added here by adding positions or orders
        /// Example: fields=positions,orders
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SecuritiesAccount[]> GetAccounts(string? fields = null, CancellationToken cancellationToken = default);
    }
}
