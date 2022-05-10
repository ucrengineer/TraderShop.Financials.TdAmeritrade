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
        public double NAV { get; set; }
        public double PeRatio { get; set; }
        public double PivAmount { get; set; }
        public double DivYield { get; set; }
        public string DivDate { get; set; } = string.Empty;
    }
}
