namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    public class RequestedWatchlist
    {
        public string Name { get; set; } = string.Empty;
        public string WatchlistId { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public ReqeustedWatchlistItem[] WatchlistItems = new ReqeustedWatchlistItem[0];

    }

    public class ReqeustedWatchlistItem : WatchlistItem
    {
        public string status { get; set; } = string.Empty;

    }
}
