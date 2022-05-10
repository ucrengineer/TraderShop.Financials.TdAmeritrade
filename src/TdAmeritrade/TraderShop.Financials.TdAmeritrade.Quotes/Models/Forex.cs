using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    public class Forex : Quote
    {
        public double BidPriceInDouble { get; set; }
        public double AskPriceInDouble { get; set; }
        public double LastPriceInDouble { get; set; }
        public double HighPriceInDouble { get; set; }
        public double LowPriceInDouble { get; set; }

        public double OpenPriceInDouble { get; set; }
        public double ChangeInDouble { get; set; }
        public double PercentChange { get; set; }
        public double Digits { get; set; }
        public double Tick { get; set; }
        public double TickAmount { get; set; }
        public string Product { get; set; } = string.Empty;
        public string TradingHours { get; set; } = string.Empty;
        public bool IsTradable { get; set; }
        public string MarketMaker { get; set; } = string.Empty;
        [JsonProperty("52WkHighInDouble")]
        public double HighInDoubleWk52 { get; set; }
        [JsonProperty("52WkLowInDouble")]
        public double LowInDoubleWk52 { get; set; }
        public double Mark { get; set; }
    }
}
