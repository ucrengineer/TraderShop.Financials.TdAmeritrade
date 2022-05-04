using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Accounts.Services;
using Xunit;

namespace TdAmeritrade.Financials.Tests
{
    public class AccountsProvider
    {
        [Fact]
        public async Task Return_Accounts_Successfully()
        {
            var test = TestHelper.GetServiceProvider();

            var accountsProvider = test.GetRequiredService<ITdAmeritradeAccountProvider>();

            var options = test.GetRequiredService<IOptionsMonitor<TdAmeritradeOptions>>();

            var accounts = await accountsProvider.GetAccounts();
        }
    }
}
