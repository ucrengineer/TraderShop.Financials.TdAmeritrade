using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    public class Equity : Quote
    {
        public double BidPrice { get; set; }
        public double BidSize { get; set; }
        public string BidId { get; set; } = string.Empty;
        public double AskPrice { get; set; }
        public double AskSize { get; set; }
        public string AskId { get; set; } = string.Empty;
        public double LastPrice { get; set; }
        public double LastSize { get; set; }
        public string LastId { get; set; } = string.Empty;
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double ClosePrice { get; set; }
        public double NetChange { get; set; }
        public double TotalVolume { get; set; }
        public double QuoteTimeInLong { get; set; }
        public double TradeTimeInLong { get; set; }
        public double Mark { get; set; }
        public bool Marginable { get; set; }
        public bool Shortable { get; set; }
        public double Volatility { get; set; }
        public double Digits { get; set; }
        [JsonProperty("52WkHigh")]
        public double WeekHigh52 { get; set; }
        [JsonProperty("52WkLow")]
        public double WeekLow52 { get; set; }
        public double PeRatio { get; set; }
        public double DivAmount { get; set; }
        public double DivYield { get; set; }
        public string DivDate { get; set; } = string.Empty;
        public double RegularMarketLastPrice { get; set; }
        public double RegularMarketLastSize { get; set; }

        public double RegularMarketNetChange { get; set; }
        public double RegularMarketTradeTimeInLong { get; set; }

    }
}
