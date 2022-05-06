using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.SavedOrders.Services;
using Xunit;

namespace TdAmeritrade.Financials.Tests
{
    public class SavedOrdersProvider
    {
        private readonly ITdAmeritradeSavedOrdersProvider _savedOrdersProvider;
        private readonly TdAmeritradeOptions _options;

        public SavedOrdersProvider()
        {
            _savedOrdersProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeSavedOrdersProvider>();
            _options = TestHelper.GetServiceProvider().GetRequiredService<IOptionsMonitor<TdAmeritradeOptions>>().CurrentValue;
        }


        [Fact]
        public async Task Throws_Exception_Saved_Orders_Not_Supported()
        {
            await Assert.ThrowsAsync<Exception>(async () => await _savedOrdersProvider.GetSavedOrdersByAccountId(_options.account_number));

        }
    }
}
