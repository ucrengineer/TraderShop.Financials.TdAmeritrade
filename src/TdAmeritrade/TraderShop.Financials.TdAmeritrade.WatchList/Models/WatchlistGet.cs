namespace TraderShop.Financials.TdAmeritrade.Watchlist.Models
{
    public class WatchlistGet
    {
        public string Name { get; set; } = string.Empty;
        public string WatchlistId { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public WatchlistItemGet[] WatchlistItems = new WatchlistItemGet[0];

    }

    public class WatchlistItemGet : WatchlistItem
    {
        public string status { get; set; } = string.Empty;

    }
}
