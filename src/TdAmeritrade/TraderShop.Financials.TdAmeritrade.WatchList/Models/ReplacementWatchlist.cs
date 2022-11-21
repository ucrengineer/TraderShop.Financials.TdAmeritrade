using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ReplacementWatchlist
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="watchlistId"></param>
        /// <param name="watchlistItems"></param>
        public ReplacementWatchlist(string name, string watchlistId, WatchlistItem[] watchlistItems)
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
        public WatchlistItem[] WatchlistItems { get; set; } = new WatchlistItem[0];
    }
}
