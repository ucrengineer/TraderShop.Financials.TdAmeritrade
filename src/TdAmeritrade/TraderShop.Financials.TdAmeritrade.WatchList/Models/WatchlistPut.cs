using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    public class WatchlistPut
    {
        public WatchlistPut(string name, string watchlistId, WatchlistItemPut[] watchlistItems)
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
        public WatchlistItemPut[] WatchlistItems { get; set; } = new WatchlistItemPut[0];
    }

    public class WatchlistItemPut : WatchlistItem
    {
        [JsonProperty("sequenceId")]
        public string SequenceId { get; set; } = string.Empty;

    }
}
