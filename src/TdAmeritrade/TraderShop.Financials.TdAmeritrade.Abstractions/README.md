## TdAmeritrade API Abstractions Library

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


## Usage

```csharp

    public class AuthServiceDemo
    {
        private readonly ITdAmeritradeAuthService _authService;

        public AuthServiceDemo(ITdAmericaritradeAuthService authService)
        {
            _authService = authService;
        }

        public async Task Returns_Bearer_Token_Successfully()
        {
            var token = await _authService.GetBearerToken();
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

    public class PostAccessTokenResponse
    {
        public string access_token { get; set; } = string.Empty;
        public string token_type { get; set; } = string.Empty;
        public int expires_in { get; set; }
        public string refresh_token { get; set; } = string.Empty;
        public string scope { get; set; } = string.Empty;

        public string error { get; set; } = string.Empty;
    }
```
 
## Description

Must have a valid Refresh Token and ClientId to use this library. The bear token is stored until it expires using IMemoryCache. Also basic models that are used throughout the project are located in the Models folder.

[TdAmeritrade API Authentication Documentation](https://developer.tdameritrade.com/authentication/apis)
