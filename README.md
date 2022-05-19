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

Data returned from the library are modeled after the [TdAmeritrade API Documentation](https://developer.tdameritrade.com/apis "TdAmeritrade's API Documentation").

IHttpClientFactory is used to create an instance of IHttpClient.

Error Handling is handled by the library, the exception thrown will have the http error message and the status code.

An error will also be thrown on Http Get requests that return a empty 
response. It is recommended to use some form of resilient mechanism to handle these events.