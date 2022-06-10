using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    public class CreatedWatchlist
    {
        public CreatedWatchlist(string name, WatchlistItem[] watchlistItems)
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
