## Movers Library

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



```csharp
public class MoverProvider
{
    private readonly ITdAmeritradeMoverProvider _moverProvider;
    public MoverProvider(ITdAmeritradeMoverProvider Provider)
    {
        _moverProvider = Provider;
    }

    public async void Returns_Movers_Successfully()
    {
        var movers = await _moverProvider.GetMovers(new MoverQuery());
    }
}
```

## Description

This library uses the TdAmeritrade API to provide information on movers for a given market and direction. See the MoverQuery object for more information.

[TdAmeritrade API Movers Documentation](https://developer.tdameritrade.com/movers/apis)