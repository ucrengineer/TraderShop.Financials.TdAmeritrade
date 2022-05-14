using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.TransactionHistory.Models;
using TraderShop.Financials.TdAmeritrade.TransactionHistory.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class TransactionHistoryProvider
    {
        private readonly ITdAmeritradeTransactionHistoryProvider _transactionHistoryProvider;
        private readonly TdAmeritradeOptions _options;
        public TransactionHistoryProvider()
        {
            _transactionHistoryProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeTransactionHistoryProvider>();
            _options = TestHelper.GetServiceProvider().GetRequiredService<IOptionsMonitor<TdAmeritradeOptions>>().CurrentValue;

        }

        [Fact]
        public async void Returns_Transactions_Successfully()
        {
            var result = await _transactionHistoryProvider.GetTransaction(_options.account_number, "42676990903");

            Assert.NotNull(result);

            Assert.Equal("42676990903", result.TransactionId.ToString());

            var result2 = await _transactionHistoryProvider.GetTransactions(_options.account_number, new TransactionQuery());

            Assert.NotNull(result2);

            Assert.True(result2.Length > 1);
        }

    }
}
