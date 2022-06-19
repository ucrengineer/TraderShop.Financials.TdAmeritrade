using Microsoft.Extensions.DependencyInjection;
using System;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Movers.Models;
using TraderShop.Financials.TdAmeritrade.Movers.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class MoverProvider
    {
        private readonly ITdAmeritradeMoverProvider _moverProvider;
        public MoverProvider()
        {
            _moverProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeMoverProvider>();
        }

        [Fact]
        public async void Returns_Movers_Successfully()
        {
            var movers = await _moverProvider.GetMovers(new MoverQuery());

            Assert.NotNull(movers);

            if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                Assert.True(movers.Length == 0);
            else
                Assert.True(movers.Length > 0);
        }
    }
}
