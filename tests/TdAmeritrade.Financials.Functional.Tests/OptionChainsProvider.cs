using Microsoft.Extensions.DependencyInjection;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.OptionChains.Models;
using TraderShop.Financials.TdAmeritrade.OptionChains.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class OptionChainsProvider
    {
        private readonly ITdAmeritradeOptionChainsProvider _optionChainsProvider;
        public OptionChainsProvider()
        {
            _optionChainsProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeOptionChainsProvider>();
        }

        [Fact]
        public async void Return_OptionChains_SuccessfullyAsync()
        {
            // arrange
            var query = new OptionChainQuery() { Symbol = "TIGR" };

            // act
            var result = await _optionChainsProvider.GetOptionChain(query);

            // assert
            Assert.NotNull(result);
            Assert.Equal("SUCCESS", result.Status);
        }

    }
}
