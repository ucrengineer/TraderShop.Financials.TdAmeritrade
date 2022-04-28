using TraderShop.Financials.TdAmeritrade.Accounts.Models;

namespace TraderShop.Financials.TdAmeritrade.Accounts.Services
{
    /// <summary>
    /// Currently only supports balances
    /// </summary>
    public interface ITdAmeritradeAccountProvider
    {
        Task<SecuritiesAccount> GetAccount(string[]? fields = null);

        Task<SecuritiesAccount[]> GetAccounts(string[]? fields = null);
    }
}
