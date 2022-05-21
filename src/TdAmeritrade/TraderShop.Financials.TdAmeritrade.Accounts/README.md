# Accounts & Trading Library

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
[TdAmeritrade API Account Endpoint Documentation](https://developer.tdameritrade.com/account-access/apis")

## Usage

```csharp

    public class AccountsProviderDemo
    {
        private readonly ITdAmeritradeAccountProvider _accountProvider;
        private readonly TdAmeritradeOptions _options;
        public AccountsProviderDemo(ITdAmeritradeAccountProvider accountProvider, TdAmeritradeOptions options)
        {
            _accountProvider = accountProvider;
            _options = options;
        }
        public async Task Return_Accounts_Successfully()
        {
            var result = await _accountProvider.GetAccounts();

        }
        public async Task Return_Account_Succesfully()
        {
            var result = await _accountProvider.GetAccount(_options.account_number);
        }
    }
```

## Description

Returns all information regarding the accounts associated with the user. The information is modeled using various models in the Models folder.
