# Watchlist Library

<img src="https://img.shields.io/github/issues/ucrengineer/TraderShop.Financials"
    alt = "home screen"
    style = "float: left"/>
<img src="https://img.shields.io/github/forks/ucrengineer/TraderShop.Financials"
    alt = "home screen"
    style = "float: left"/>
<img src="https://img.shields.io/github/stars/ucrengineer/TraderShop.Financials"
    alt = "home screen"
    style = "float: left"/>
<img src="https://img.shields.io/github/license/ucrengineer/TraderShop.Financials.TdAmeritrade"
    alt = "home screen"
    style = "float: left"/>

<br></br>
<a href="https://www.buymeacoffee.com/ucrengineer" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>

<br></br>
[TdAmeritrade API Documentation](https://developer.tdameritrade.com/watchlist/apis)

## Usage

```csharp
    public class WatchlistProvider
    {
        private readonly ITdAmeritradeWatchlistProvider _watchlistProvider;
        private readonly TdAmeritradeOptions _options;

        public WatchlistProvider(ITdAmeritradeWatchlistProvider watchlistProvider, TdAmeritradeOptions options)
        {
            _watchlistProvider = watchlistProvider;
            _options = options;
        }

        public async void BasicExample()
        {
            var newWatchlist = new CreatedWatchlist(name: "apiTest",
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

            var result = await _watchlistProvider.CreateWatchlist(_options.account_number, newWatchlist);

            var result = await _watchlistProvider.DeleteWatchlist(_options.account_number, "1930659840");

            var result = await _watchlistProvider.GetWatchlist(_options.account_number, "1927749188");

            var result = await _watchlistProvider.GetWatchlistsForMultipleAccounts();

            var result = await _watchlistProvider.GetWatchlistsForSingleAccounts(_options.account_number);

        }
    }

```

## Description

This library provides a way to interact with the TdAmeritrade API's Watchlist endpoints. See the WatchlistPost and WatchlistQuery objects for more information.
