# Quotes Library

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
[TdAmeritrade API Documentation](https://developer.tdameritrade.com/quotes/apis "TdAmeritrade's API Documentation")

## Usage

``` csharp

public class QuotesProvider
    {
        private readonly ITdAmeritradeQuotesProvider _quotesProvider;

        public QuotesProvider(ITdAmeritradeQuotesProvider Provider)
        {
            _quotesProvider = Provider;
        }

        public async void BasicExample()
        {
            var quote = await _quotesProvider.GetQuote<Quote>("MSFT");

            var future = await _quotesProvider.GetQuote<Future>("MSFT");

            var futureOptions = await _quotesProvider.GetQuote<FutureOptions>("MSFT");

            var mutualFunds = await _quotesProvider.GetQuote<MutualFund>("MSFT");

            var results = await _quotesProvider.GetQuotes(symbols: new string[] { "MSFT", "/KC", "EUR/USD" });

        }
    }
```

## Description

This library uses the TdAmeritrade API to provide information on quotes for a given symbol. See the Quote, Future, FutureOptions, and MutualFund classes for more information.