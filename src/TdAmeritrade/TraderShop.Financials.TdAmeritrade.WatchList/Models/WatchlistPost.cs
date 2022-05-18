using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Watchlist.Models
{
    public class WatchlistPost
    {
        public WatchlistPost(string name, WatchlistItem[] watchlistItems)
        {
            Name = name;
            WatchlistItems = watchlistItems;
        }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("watchlistItems")]
        public WatchlistItem[] WatchlistItems { get; set; } = new WatchlistItem[0];
    }
}
