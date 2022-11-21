using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Equity : Quote
    {
        /// <summary>
        /// 
        /// </summary>
        public double BidPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BidSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BidId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double AskPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double AskSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AskId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public double LastPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double LastSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastId { get; set; } = string.Empty;
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
        public double QuoteTimeInLong { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double TradeTimeInLong { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Mark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Marginable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Shortable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double Volatility { get; set; }
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
        public double PeRatio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double DivAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double DivYield { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DivDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RegularMarketLastPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RegularMarketLastSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double RegularMarketNetChange { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RegularMarketTradeTimeInLong { get; set; }

    }
}
