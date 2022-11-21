using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;
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
        public async void Create_Get_Delete_SuccessfullyAsync()
        {
            var testWatchlistName = new Guid().ToString();

            // arrange
            var newWatchlist = new CreatedWatchlist(name: $"{testWatchlistName}",
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

            var watchlists = await _watchlistProvider.GetWatchlistsForSingleAccounts(_options.account_number);

            foreach (var watchlist in watchlists)
            {
                if (watchlist.Name == testWatchlistName)
                {
                    var deleteResult = await _watchlistProvider.DeleteWatchlist(watchlist.AccountId, watchlist.WatchlistId);
                    Assert.Equal(0, deleteResult);
                }
            }
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
