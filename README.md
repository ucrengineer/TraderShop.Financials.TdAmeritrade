## TdAmeritrade API Wrapper
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

<a href="buymeacoffee.com/ucrengineer" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;" ></a>


[TdAmeritrade API Official Documentation](https://developer.tdameritrade.com/apis "TdAmeritrade's API Documentation")

### Description

This library wraps the following endpoints from the TdAmeritrade Developer API :
1. Accounts and Trading 
2. Authentication
3. Instruments
4. Market Hours
5. Movers
6. Option Chains
7. Price History
8. Quotes
9. Transaction History
10. User Info and Preferences
11. Watchlist

## Accounts and Trading
<b>Saved Orders endpoints are not wrapped</b>.

Still working on consolidating models for Orders enpoints.
## Authentication
Located in the `TraderShop.Financials.TdAmeritrade.Abstractions` project.
Bearer Token is cached in memory. Absolute expiration is set to the "Expires_In" value that is returned from the TdAmeritrade API. Currently only Bearer Tokens are supported and is done using embedded Tdameritrade account information.

## Instruments
<b>GetAllForexInstruments is currently not implemented</b>

## Market Hours

## Movers

## Option Chains

## Price History

## Quotes

## Transaction History

## User Info and Preferences

## Watchlist
Still working on consolidating models.
## ErrorHandling
The library will throw an exception if the TdAmeritrade API returns an error code or if there are no objects returned.
The exception will contain the error code and message.
