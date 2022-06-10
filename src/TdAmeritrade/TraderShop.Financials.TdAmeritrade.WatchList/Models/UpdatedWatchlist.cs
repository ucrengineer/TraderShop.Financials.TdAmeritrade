using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    public class UpdatedWatchlist
    {
        public UpdatedWatchlist(string name, string watchlistId, UpdatedWatchlistItem[] watchlistItems)
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
        public UpdatedWatchlistItem[] WatchlistItems { get; set; } = new UpdatedWatchlistItem[0];
    }

    public class UpdatedWatchlistItem : WatchlistItem
    {
        [JsonProperty("sequenceId")]
        public string SequenceId { get; set; } = string.Empty;

    }
}
