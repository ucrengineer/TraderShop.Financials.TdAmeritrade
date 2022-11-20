using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Index : Quote
    {
        /// <summary>
        /// 
        /// </summary>
        public double LastPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double OpenPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double HighPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LowPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ClosePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double NetChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TotalVolume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TradeTimeInLong { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Digits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("52WkHigh")]
        public double WeekHigh52 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("52WkLow")]
        public double WeekLow52 { get; set; }

    }
}
