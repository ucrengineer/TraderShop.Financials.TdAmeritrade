using TraderShop.Financials.TdAmeritrade.Quotes.Models;

namespace TraderShop.Financials.TdAmeritrade.OptionChains.Models
{
    public class OptionChain
    {
        public string Symbol { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public Underlying? Underlying { get; set; }
        public string Strategy { get; set; } = string.Empty;
        public double Interval { get; set; }
        public bool IsDelayed { get; set; }
        public bool IsIndex { get; set; }
        public double DaysToExpiration { get; set; }
        public double InterestRate { get; set; }
        public double UnderlyingPrice { get; set; }
        public double Volatility { get; set; }
        public Dictionary<string, Dictionary<string, DetailedOption[]>>? CallExpDateMap { get; set; }
        public Dictionary<string, Dictionary<string, DetailedOption[]>>? PutExpDateMap { get; set; }

    }

    public class Underlying
    {
        public double Ask { get; set; }
        public double AskSize { get; set; }
        public double BidSize { get; set; }
        public double Change { get; set; }
        public double Close { get; set; }
        public bool Delayed { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ExchangeName { get; set; } = string.Empty;
        public double FiftyTwoWeekHigh { get; set; }
        public double FiftyTowWeekLow { get; set; }
        public double HighPrice { get; set; }
        public double Last { get; set; }
        public double LowPrice { get; set; }
        public double Mark { get; set; }
        public double MarkChange { get; set; }
        public double MarkPercentageChange { get; set; }
        public double OpenPrice { get; set; }
        public double PercentChange { get; set; }
        public double QuoteTime { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public double TotalVolume { get; set; }
        public double TradeTime { get; set; }
    }

    public class DetailedOption : Option
    {
        public string DeliverableNote { get; set; } = string.Empty;
        public long ExpirationDate { get; set; }
        public string ExpirationType { get; set; } = string.Empty;
        public long? TradeDate { get; set; }
        public bool? IsIndexOption { get; set; }
        public bool IsInTheMoney { get; set; }
        public bool IsMini { get; set; }
        public bool IsNonStandard { get; set; }
        public double MarkChange { get; set; }
        public double MarkPercentChange { get; set; }
        public double MarkPrice { get; set; }
        public OptionDeliverable[]? OptionDeliverablesList { get; set; }
        public double PercentChange { get; set; }
        public string PutCall { get; set; } = string.Empty;
        public double TheoreticalVolatility { get; set; }
    }
    public class OptionDeliverable
    {
        public string AssetType { get; set; } = string.Empty;
        public string CurrencyType { get; set; } = string.Empty;
        public string DeliverableUnits { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
    }
}
