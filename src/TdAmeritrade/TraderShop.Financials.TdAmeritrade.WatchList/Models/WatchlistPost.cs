using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Watchlist.Models
{
    public class WatchlistPost
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("watchlistItems")]
        public WatchlistItem[] WatchlistItems { get; set; } = new WatchlistItem[0];
    }
}
