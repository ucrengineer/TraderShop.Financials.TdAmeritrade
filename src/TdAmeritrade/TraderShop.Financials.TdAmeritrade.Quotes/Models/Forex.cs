using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Forex : Quote
    {
        /// <summary>
        /// 
        /// </summary>
        public double BidPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double AskPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LastPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HighPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LowPriceInDouble { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double OpenPriceInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ChangeInDouble { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PercentChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Digits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Tick { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TickAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Product { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string TradingHours { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public bool IsTradable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MarketMaker { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("52WkHighInDouble")]
        public double HighInDoubleWk52 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("52WkLowInDouble")]
        public double LowInDoubleWk52 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Mark { get; set; }
    }
}
