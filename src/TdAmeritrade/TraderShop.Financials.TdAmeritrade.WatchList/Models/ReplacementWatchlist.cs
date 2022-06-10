using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    public class ReplacementWatchlist
    {
        public ReplacementWatchlist(string name, string watchlistId, WatchlistItem[] watchlistItems)
        {
            Name = name;
            WatchlistId = watchlistId;
            WatchlistItems = watchlistItems;
        }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("watchlistId")]
        public string WatchlistId { get; set; } = string.Empty;
        [JsonProperty("watchlistItems")]
        public WatchlistItem[] WatchlistItems { get; set; } = new WatchlistItem[0];
    }
}
