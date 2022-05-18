using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Watchlist.Models;
using TraderShop.Financials.TdAmeritrade.Watchlist.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
{
    public class WatchlistProvider
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        private readonly TdAmeritradeOptions _options;
        public WatchlistProvider()
        {
            _watchlistProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeWatchlistProvider>();
            _options = TestHelper.GetServiceProvider().GetRequiredService<IOptionsMonitor<TdAmeritradeOptions>>().CurrentValue;
        }

        [Fact]
        public async void Create_Watchlist_SuccessfullyAsync()
        {
            // arrange
            var newWatchlist = new WatchlistPost(name: "apiTest",
                watchlistItems: new[]
                {
                    new WatchlistItem
                    {
                        Quantity = 100,
                        Commission = 0,
                        PurchaseDate = DateTime.Now.AddYears(-20).ToString("yyyy-MM-dd"),
                        BasicInstrumnet = new BasicInstrument()
                        {
                            Symbol = "MSFT",
                            AssetType = "EQUITY"
                        }
                    }
                })
            {

            };

            // act
            var result = await _watchlistProvider.CreateWatchlist(_options.account_number, newWatchlist);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public async void Delete_Watchlist_SuccessfullyAsync()
        {
            var result = await _watchlistProvider.DeleteWatchlist(_options.account_number, "1930659840");

            Assert.Equal(0, result);
        }

        [Fact]
        public async void Return_Watchlist_SuccessfullyAsync()
        {
            var result = await _watchlistProvider.GetWatchlist(_options.account_number, "1927749188");

            Assert.NotNull(result);

            Assert.Equal(_options.account_number, result.AccountId);
        }

        [Fact]
        public async void Return_Watchlists_From_Multiple_Accounts_SuccessfullyAsync()
        {
            var result = await _watchlistProvider.GetWatchlistsForMultipleAccounts();

            Assert.NotNull(result);

            Assert.Contains(result, x => x.AccountId == _options.account_number);
        }

        [Fact]
        public async void Return_Watchlists_From_Single_Account_SuccessfullyAsync()
        {
            var result = await _watchlistProvider.GetWatchlistsForSingleAccounts(_options.account_number);

            Assert.NotNull(result);

            Assert.Contains(result, x => x.AccountId == _options.account_number);
        }
    }
}
