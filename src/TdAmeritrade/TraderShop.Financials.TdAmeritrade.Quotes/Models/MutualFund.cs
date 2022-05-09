using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Models
{
    public class MutualFund : Quote
    {
        public double NetChange { get; set; }
        public double TotalVolume { get; set; }
        public double TradeTimeInLong { get; set; }
        public double Digits { get; set; }
        [JsonProperty("52WkHigh")]
        public double WeekHigh52 { get; set; }
        [JsonProperty("52WkLow")]
        public double WeekLow52 { get; set; }
        public double nAV { get; set; }
        public double peRatio { get; set; }
        public double divAmount { get; set; }
        public double divYield { get; set; }
        public string divDate { get; set; } = string.Empty;
    }
}
