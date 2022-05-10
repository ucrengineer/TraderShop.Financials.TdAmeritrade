using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    public class Index : Quote
    {
        public double LastPrice { get; set; }
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double ClosePrice { get; set; }
        public double NetChange { get; set; }
        public double TotalVolume { get; set; }
        public double TradeTimeInLong { get; set; }
        public double Digits { get; set; }
        [JsonProperty("52WkHigh")]
        public double WeekHigh52 { get; set; }
        [JsonProperty("52WkLow")]
        public double WeekLow52 { get; set; }

    }
}
