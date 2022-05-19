## Price History Library

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
    public class PriceHistoryProviderDemo
    {
        private readonly ITdAmeritradePriceHistoryProvider _priceHistoryProvider;

        public PriceHistoryProviderDemo(ITdAmeritradePriceHistoryProvider priceHistoryProvider)
        {
            _priceHistoryProvider = priceHistoryProvider;
        }

        public async Task Return_PriceHistory_Successfully()
        {
            var result = await _priceHistoryProvider.GetPriceHistory(new PriceHistorySpecs());

            Assert.NotNull(result);
            Assert.Contains(result, x => x.Close != 0);
        }
              
        // Input model  
        public class PriceHistorySpecs
        {
            /// Instrument symbol. Default is AAPL.
            public string Symbol { get; set; } = "AAPL";
    
            /// The type of period to show. Default is <b>day</b>.
            public PeriodType PeriodType { get; set; } = PeriodType.year;
    
            /// The number of periods to show. Valid periods by periodType (defaults marked with an asterisk):
            public int Period { get; set; } = 1;
    
            /// The type of frequency with which a new candle is formed.
            /// Valid frequencyTypes by periodType (defaults marked with an asterisk):
            public FrequecyType FrequecyType { get; set; } = FrequecyType.daily;
            /// The number of the frequencyType to be included in each candle.
            /// Valid frequencies by frequencyType (defaults marked with an asterisk):
    
            public int Frequency { get; set; } = 1;
            /// End date as milliseconds since epoch.
            /// If startDate and endDate are provided, period should not be provided.
            /// Default is previous trading day.
            public DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now.AddDays(-1);
    
            /// Start date as milliseconds since epoch. If startDate and endDate are provided, period should not be provided.
            public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now.AddYears(-1);
    
            /// <b>true</b> to return <b>extended hours data</b>,<b>false</b> for <b>regular market hours</b> only.<b>Default</b>  is <b>true</b>.
            public bool NeedExtendedHoursData { get; set; } = true;
    
        }
    
        public enum PeriodType
        {
            day,
            month,
            year,
            ytd
        }
    
        public enum FrequecyType
        {
            minute,
            daily,
            weekly,
            monthly
        }
        
        // output model 
            public class Candle
        {
            public decimal Close { get; set; }
    
            public long DateTime { get; set; }
    
            public decimal High { get; set; }
    
            public decimal Low { get; set; }
    
            public decimal Open { get; set; }
    
            public long Volume { get; set; }
        }
    
        public class PriceHistoryRoot
        {
            public Candle[] Candles { get; set; } = new Candle[0];
    
            public bool Empty { get; set; }
    
            public string Symbmol { get; set; } = string.Empty;
    
        }

    }
```

## Description

This library is in charge of returning price histories for a given instrument.

[TdAmeritrade API PriceHistory Documentation](https://developer.tdameritrade.com/price-history/apis)
