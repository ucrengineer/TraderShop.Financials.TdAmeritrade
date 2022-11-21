# TdAmeritrade API Abstractions Library

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
[TdAmeritrade API Authentication Documentation](https://developer.tdameritrade.com/authentication/apis)

## Usage

```csharp

    public class AuthServiceDemo
    {
        private readonly ITdAmeritradeAuthService _authService;

        public AuthServiceDemo(ITdAmericaritradeAuthService authService)
        {

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
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

Must have a valid Refresh Token and ClientId to use the TdAmeritrade library. The bear token is stored until it expires using IMemoryCache. Also basic models that are used throughout the project are located in the Models project. 