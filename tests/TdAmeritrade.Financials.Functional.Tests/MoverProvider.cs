using Microsoft.Extensions.DependencyInjection;
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
        }
    }
}
