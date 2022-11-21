using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdatedWatchlist
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="watchlistId"></param>
        /// <param name="watchlistItems"></param>
        public UpdatedWatchlist(string name, string watchlistId, UpdatedWatchlistItem[] watchlistItems)
        {
            Name = name;
            WatchlistId = watchlistId;
            WatchlistItems = watchlistItems;
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("watchlistId")]
        public string WatchlistId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("watchlistItems")]
        public UpdatedWatchlistItem[] WatchlistItems { get; set; } = new UpdatedWatchlistItem[0];
    }

    /// <summary>
    /// 
    /// </summary>
    public class UpdatedWatchlistItem : WatchlistItem
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sequenceId")]
        public string SequenceId { get; set; } = string.Empty;

    }
}
