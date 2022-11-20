using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MutualFund : Quote
    {
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
        /// <summary>
        /// 
        /// </summary>
        public double NAV { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PeRatio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double PivAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double DivYield { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DivDate { get; set; }
    }
}
