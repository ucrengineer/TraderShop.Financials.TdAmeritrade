# User Information & Preferences Library

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
[TdAmeritrade API Documentation](https://developer.tdameritrade.com/user-principal/apis "TdAmeritrade's API Documentation")


## Usage

```csharp
    public class UserInformationProvider
    {
        private readonly ITdAmeritradeUserInformationProvider _userInformationProvider;
        private readonly TdAmeritradeOptions _options;

        public UserInformationProvider(ITdAmeritradeUserInformationProvider userInformationProvider, TdAmeritradeOptions options)
        {
            _userInformationProvider = userInformationProvider;
            _options = options;
        }

        public async void BasicExample()
        {

            var result = await _userInfoProvider.GetPreferences(_options.account_number);   
    
            var result = await _userInfoProvider.GetStreamerSubscriptionKeys();
    
            var updatedPreferences = new Preferences()
            {
                ExpressTrading = false,
                DirectOptionsRouting = false,
                DirectEquityRouting = false,
                DefaultEquityOrderLegInstruction = "BUY",
                DefaultEquityOrderType = "STOP",
                DefaultEquityOrderPriceLinkType = "NONE",
                DefaultEquityOrderDuration = "GOOD_TILL_CANCEL",
                DefaultEquityOrderMarketSession = "NORMAL",
                DefaultEquityQuantity = 0,
                MutualFundTaxLotMethod = "FIFO",
                EquityTaxLotMethod = "FIFO",
                OptionTaxLotMethod = "FIFO",
                DefaultAdvancedToolLaunch = "TA",
                AuthTokenTimeout = "FIFTY_FIVE_MINUTES"
            };
      
            var result = await _userInfoProvider.UpdatePreferences(_options.account_number, updatedPreferences);
       
            var result = await _userInfoProvider.GetUserPrincipals();
        }

    }
```

## Description

This library uses the TdAmeritrade API to retrieve user information and preferences. see the Preferences object for more information.