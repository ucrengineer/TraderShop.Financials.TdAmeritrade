# Market HoursLibrary

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
[TdAmeritrade API Documentation](https://developer.tdameritrade.com/market-hours/apis)

## Usage

```csharp

    public class MarketHoursProvider
    {
        private readonly ITdAmeritradeMarketHoursProvider _hoursProvider;

        public MarketHoursProvider(ITdAmeritradeMarketHours Provider)
        {
            _hoursProvider = Provider;
        }

        public async void Return_Hours_Successfully()
        {
            var result = await _hoursProvider.GetHoursForMultipleMarkets
                (new MarketHoursQuery() { Date = DateTime.Now.AddDays(4), Markets = new string[] { "FUTURE" } }, CancellationToken.None);

        }

    }
```

## Description

This library is in charge of providing information on market hours. Notice that most of these methods use MarketHoursQuery objects to specify the market and date. When using the object please hover over to see the properties.
