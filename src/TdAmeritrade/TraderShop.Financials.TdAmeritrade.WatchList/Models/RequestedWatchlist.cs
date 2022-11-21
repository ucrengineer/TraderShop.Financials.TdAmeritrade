namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class RequestedWatchlist
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WatchlistId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AccountId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public ReqeustedWatchlistItem[] WatchlistItems = new ReqeustedWatchlistItem[0];

    }

    /// <summary>
    /// 
    /// </summary>
    public class ReqeustedWatchlistItem : WatchlistItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; } = string.Empty;

    }
}
