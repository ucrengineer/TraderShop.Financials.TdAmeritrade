# Saved Orders Library

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
[TdAmeritrade API Documentation](https://developer.tdameritrade.com/account-access/apis "TdAmeritrade's API Documentation")


```csharp
    public class SavedOrdersProvider
    {
        private readonly ITdAmeritradeSavedOrdersProvider _savedOrdersProvider;
        private readonly TdAmeritradeOptions _options;

        public SavedOrdersProvider(ITdAmeritradeSavedOrdersProvider savedOrdersProvider, TdAmeritradeOptions options)
        {
            _savedOrdersProvider = savedOrdersProvider;
            _options = options;
        }

        public async Task Throws_Exception_Saved_Orders_Not_Supported()
        {
            await Assert.ThrowsAsync<Exception>(async () => await _savedOrdersProvider.GetSavedOrdersByAccountId(_options.account_number));

        }
    }
```

## Description

This library currently isn't being implemented.
