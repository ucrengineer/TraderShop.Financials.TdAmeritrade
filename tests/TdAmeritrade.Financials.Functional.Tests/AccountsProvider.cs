using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Accounts.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class AccountsProvider
    {
        private readonly ITdAmeritradeAccountProvider _accountProvider;
        private readonly TdAmeritradeOptions _options;
        public AccountsProvider()
        {
            _accountProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeAccountProvider>();
            _options = TestHelper.GetServiceProvider().GetRequiredService<IOptionsMonitor<TdAmeritradeOptions>>().CurrentValue;
        }
        [Fact]
        public async Task Return_Accounts_Successfully()
        {
            var result = await _accountProvider.GetAccounts();

            Assert.NotNull(result);
            Assert.True(result.All(x => x.AccountId.Any()));

        }

        [Fact]
        public async Task Return_Account_Succesfully()
        {
            var result = await _accountProvider.GetAccount(_options.account_number);

            Assert.NotNull(result);
            Assert.Equal(_options.account_number, result.AccountId);
        }

        [Theory]
        [InlineData("")]
        [InlineData("343343")]
        public async Task Throws_Exception(string faultyAccountId)
        {
            await Assert.ThrowsAsync<Exception>(() => _accountProvider.GetAccount(faultyAccountId));

        }

    }
}
