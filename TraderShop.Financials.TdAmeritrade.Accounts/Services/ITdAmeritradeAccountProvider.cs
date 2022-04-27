using TraderShop.Financials.TdAmeritrade.Accounts.Models;

namespace TraderShop.Financials.TdAmeritrade.Accounts.Services
{
    public interface ITdAmeritradeAccountProvider
    {
        Task<SecuritiesAccount> GetAccount(string[]? fields = null);
    }
}
