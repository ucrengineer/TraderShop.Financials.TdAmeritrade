## TdAmeritrade API Library

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

[TdAmeritrade API Documentation](https://developer.tdameritrade.com/apis "TdAmeritrade's API Documentation")


### Description

This library wraps the following endpoints from the TdAmeritrade Developer API :

* Accounts and Trading
* Authentication
* Instruments
* Market Hours
* Movers
* Option Chains
* Price History
* Quotes
* Transaction History
* User Info and Preferences
* Watchlist

## Usage 

```csharp
public class BasicUsageDemo
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddTdAmeritradeClient()
            .Configure<TdAmeritradeOptions>(
                hostContext.Configuration.GetSection("TdAmeritradeOptions")
                    )
            .AddFinancialsAbstractionsServices()
            .AddTdAmeritradeInstrumentProvider()
            .AddTdAmeritradePriceHistoryProvider()
            .AddTdAmeritradeAccountProvider()
            .AddTdAmeritradeSavedOrdersProvider()
            .AddTdAmeritradeOrdersProvider()
            .AddTdAmeritradeQuotesProvider()
            .AddTdAmeritradeMoverProvider()
            .AddTdAmeritradeMarketHoursProvider()
            .AddTdAmeritradeTransactionHistoryProvider()
            .AddTdAmeritradeUserInfoProvider()
            .AddTdAmeritradeOptionChainsProvider()
            .AddTdAmeritradeWatchlistProvider()
            .BuildServiceProvider();
    }

    public class BasicImplementation
    {
        private readonly ITdAmeritradeMarketHoursProvider _hoursProvider;

        public MarketHoursProvider(ITdAmeritradeMarketHoursProvider hoursProvider)
        {
            _hoursProvider = hoursProvider;
        }

        public Task<Hour[]> GetHoursAsync(string symbol)
        {
            var result = await _hoursProvider.GetHoursForMultipleMarkets
                (new MarketHoursQuery() { Date = DateTime.Now.AddDays(4), Markets = new string[] { "FUTURE" } }, CancellationToken.None);
        }
    }

    public class TdAmeritradeOptions
        {
            public string auth_url { get; set; } = string.Empty;
            public string client_id { get; set; } = string.Empty;
            public string refresh_token { get; set; } = string.Empty;
            public string redirect_uri { get; set; } = string.Empty;
            public string account_number { get; set; } = string.Empty;
        }
}


```

## - Authentication
Located in the `TraderShop.Financials.TdAmeritrade.Abstractions` project.
Imemorycache is used to cache the bearer token. Absolute expiration is set to the "Expires_In" value that is returned from the TdAmeritrade API.
Must have the following environment variables set:
    * refresh_token
    * client_id

## Usage - Accounts and Trading

<b>Saved Orders endpoints are not implemented in this library</b>
Still working on consolidating models for Orders enpoints.

## Instruments

<b>GetAllForexInstruments is currently not implemented</b>

## Watchlist

Still working on consolidating models.

## ErrorHandling

The library will throw an exception if the TdAmeritrade API returns an error code or if there are no objects returned.
The exception will contain the error code and message.
