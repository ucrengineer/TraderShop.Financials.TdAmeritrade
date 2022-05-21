# Option Chains Library

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
[TdAmeritrade API Documentation](https://developer.tdameritrade.com/option-chains/apis)

## Usage

```csharp

    public class OptionChainsProvider
    {
        private readonly ITdAmeritradeOptionChainsProvider _optionChainsProvider;
        public OptionChainsProvider(ITdAmeritradeOptionChainsProvider Provider)
        {
            _optionChainsProvider = Provider;
        }

        public async void Return_OptionChains_SuccessfullyAsync()
        {
            var query = new OptionChainQuery() { Symbol = "TIGR" };

            var result = await _optionChainsProvider.GetOptionChain(query);
        }

    }
```

## Description

This libraries job is to return option chains for a given symbol. See the OptionChainQuery object for more information on the filters that can be provided.
