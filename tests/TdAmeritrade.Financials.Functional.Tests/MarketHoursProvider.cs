using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.MarketHours.Models;
using TraderShop.Financials.TdAmeritrade.MarketHours.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class MarketHoursProvider
    {
        private readonly ITdAmeritradeMarketHoursProvider _hoursProvider;
        public MarketHoursProvider()
        {
            _hoursProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeMarketHoursProvider>();
        }

        [Fact]
        public async void Return_Hours_Successfully()
        {
            var result = await _hoursProvider.GetHoursForMultipleMarkets
                (new MarketHoursQuery() { Date = DateTime.Now.AddDays(4), Markets = new string[] { "FUTURE" } }, CancellationToken.None);

            Assert.NotNull(result);

            Assert.True(result.Length > 0);

            Assert.Contains(result, x => x.ProductName.Any());

            var result2 = await _hoursProvider.GetHoursForMultipleMarkets
                 (new MarketHoursQuery() { Date = DateTime.Now.AddDays(4), Markets = new string[] { "FUTURE" } }, CancellationToken.None);

            Assert.NotNull(result2);

            Assert.True(result2.Length > 0);

            Assert.Contains(result, x => x.ProductName.Any());
        }

    }
}
