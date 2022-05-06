using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Instruments.Services;
using Xunit;

namespace TdAmeritrade.Financials.Tests
{
    public class InstrumentProvider
    {
        private readonly ITdAmeritradeInstrumentProvider _instrumentProvider;
        public InstrumentProvider()
        {
            _instrumentProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeInstrumentProvider>();
        }
        [Theory]
        [InlineData("TIGR")]
        [InlineData("AAPL")]
        [InlineData("/KC")]
        public async Task Return_Instrument_Successfully(string symbol)
        {
            var result = await _instrumentProvider.GetInstrument(symbol);

            Assert.NotNull(result);

            Assert.Contains(symbol, result.Symbol);
        }

        [Fact]
        public async Task Return_Instruments_Successfully()
        {
            var result = await _instrumentProvider.GetInstruments(new string[] { "TIGR", "AAPL" });

            Assert.NotNull(result);

            Assert.Equal(2, result.Count);
        }

    }
}
