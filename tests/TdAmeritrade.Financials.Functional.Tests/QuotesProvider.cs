using Microsoft.Extensions.DependencyInjection;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Quotes.Models;
using TraderShop.Financials.TdAmeritrade.Quotes.Services;
using Xunit;
using Xunit.Abstractions;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class QuotesProvider
    {
        private readonly ITdAmeritradeQuotesProvider _quotesProvider;
        private readonly ITestOutputHelper _output;

        public QuotesProvider(ITestOutputHelper output)
        {
            _output = output;
            _quotesProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeQuotesProvider>();
        }

        [Fact]
        public async void Return_Correct_QuoteType_Successfully()
        {
            var quote = await _quotesProvider.GetQuote<Quote>("MSFT");

            Assert.IsType<Quote>(quote);

            var future = await _quotesProvider.GetQuote<Future>("MSFT");

            Assert.IsType<Future>(future);

            var futureOptions = await _quotesProvider.GetQuote<FutureOptions>("MSFT");

            Assert.IsType<FutureOptions>(futureOptions);

            var mutualFunds = await _quotesProvider.GetQuote<MutualFund>("MSFT");

            Assert.IsType<MutualFund>(mutualFunds);
        }

        [Fact]
        public async void Return_Quotes_Successfully()
        {
            var results = await _quotesProvider.GetQuotes(symbols: new string[] { "MSFT", "/KC", "EUR/USD" });

            Assert.NotNull(results);

        }

    }
}
