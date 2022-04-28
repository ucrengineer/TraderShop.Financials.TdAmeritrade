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
        /// <param name="accountNumber"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        Task<SecuritiesAccount> GetAccount(string accountNumber, string[]? fields = null);

        /// <summary>
        /// Balances displayed by default, additional fields can be added here by adding positions or orders
        /// Example: fields=positions,orders
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        Task<SecuritiesAccount[]> GetAccounts(string[]? fields = null);
    }
}
