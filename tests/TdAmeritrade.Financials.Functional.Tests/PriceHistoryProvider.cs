using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class PriceHistoryProvider
    {
        private readonly ITdAmeritradePriceHistoryProvider _priceHistoryProvider;

        public PriceHistoryProvider()
        {
            _priceHistoryProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradePriceHistoryProvider>();
        }

        [Fact]
        public async Task Return_PriceHistory_Successfully()
        {
            var result = await _priceHistoryProvider.GetPriceHistory(new PriceHistorySpecs());

            Assert.NotNull(result);
            Assert.Contains(result, x => x.Close != 0);
        }
        [Fact]
        public async Task Throws_Exception()
        {
            await Assert.ThrowsAsync<Exception>(async () => await _priceHistoryProvider.GetPriceHistory(new PriceHistorySpecs() { PeriodType = PeriodType.ytd, Period = 20 }));
        }
    }
}