using TraderShop.Financials.TdAmeritrade.Quotes.Models;

namespace TraderShop.Financials.TdAmeritrade.OptionChains.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class OptionChain
    {
        /// <summary>
        /// 
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public Underlying? Underlying { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Strategy { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double Interval { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDelayed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double DaysToExpiration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double InterestRate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double UnderlyingPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Volatility { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, Dictionary<string, DetailedOption[]>>? CallExpDateMap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, Dictionary<string, DetailedOption[]>>? PutExpDateMap { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class Underlying
    {
        /// <summary>
        /// 
        /// </summary>
        public double Ask { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double AskSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BidSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Change { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Close { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Delayed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ExchangeName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double FiftyTwoWeekHigh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double FiftyTowWeekLow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HighPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Last { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LowPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Mark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MarkChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MarkPercentageChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double OpenPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PercentChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double QuoteTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double TotalVolume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TradeTime { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DetailedOption : Option
    {
        /// <summary>
        /// 
        /// </summary>
        public string DeliverableNote { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public long ExpirationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ExpirationType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public long? TradeDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? IsIndexOption { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsInTheMoney { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsMini { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNonStandard { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MarkChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MarkPercentChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MarkPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OptionDeliverable[]? OptionDeliverablesList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PercentChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PutCall { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double TheoreticalVolatility { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class OptionDeliverable
    {
        /// <summary>
        /// 
        /// </summary>
        public string AssetType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string CurrencyType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DeliverableUnits { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Symbol { get; set; } = string.Empty;
    }
}
