using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatedWatchlist
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="watchlistItems"></param>
        public CreatedWatchlist(string name, WatchlistItem[] watchlistItems)
        {
            Name = name;
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
        [JsonProperty("watchlistItems")]
        public WatchlistItem[] WatchlistItems { get; set; } = new WatchlistItem[0];
    }
}
