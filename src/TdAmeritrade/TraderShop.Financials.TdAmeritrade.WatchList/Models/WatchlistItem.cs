using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Watchlist.Models
{
    public class WatchlistItem
    {
        [JsonProperty("quantity")]
        public double Quantity { get; set; }
        [JsonProperty("averagePrice")]
        public double AveragePrice { get; set; }
        [JsonProperty("commission")]
        public double Commission { get; set; }
        [JsonProperty("purchasedDate")]
        public string PurchaseDate { get; set; } = string.Empty;
        [JsonProperty("instrument")]
        public BasicInstrument BasicInstrumnet { get; set; } = new BasicInstrument();
    }
}
