# Instruments Library

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

[TdAmeritrade API Instruments Documentation](https://developer.tdameritrade.com/instruments/apis)

## Usage 

```csharp
  public class InstrumentProvider
    {
        private readonly ITdAmeritradeInstrumentProvider _instrumentProvider;
        public InstrumentProvider(ITdAmeritradeInstrumentProvider instrumentProvider)
        {
            _instrumentProvider = instrumentProvider;
        }

        public async Task Return_Instrument_Successfully(string symbol)
        {
            var result = await _instrumentProvider.GetInstrument(symbol);
        }

        public async Task Return_Instruments_Successfully()
        {
            var result = await _instrumentProvider.GetInstruments(symbols: new string[] { "TIGR", "AAPL" });
        }

    }

```

## Description

This library is in charge of providing information on instruments (stock tickers, futures tickers, etc).

A single instrument can be requested by using GetInstrument(string symbol) or a list of instruments can be requested by using GetInstruments(string[] symbols).

Also by calling GetAllFuturesInstruments() you can get a list of all of TdAmeritrade's futures instruments listed on their website.

__Note individual contracts are not supported__

GetAllForexInstruments() is currently not implemented.
