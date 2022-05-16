using TraderShop.Financials.TdAmeritrade.Watchlist.Models;

namespace TraderShop.Financials.TdAmeritrade.Watchlist.Services
{
    public interface ITdAmeritradeWatchlistProvider
    {
        /// <summary>
        /// Create watchlist for specific account.This method does not verify that the symbol or asset type are valid.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CreateWatchlist(string accountId, WatchlistPost watchlist, CancellationToken cancellationToken = default);
        /// <summary>
        /// Delete watchlist for a specific account.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> DeleteWatchlist(string accountId, string watchlistId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Specific watchlist for a specific account.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<WatchlistGet> GetWatchlist(string accountId, string watchlistId, CancellationToken cancellationToken = default);
        /// <summary>
        /// All watchlists for all of the user's linked accounts.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<WatchlistGet[]> GetWatchlistsForMultipleAccounts(CancellationToken cancellationToken = default);
        /// <summary>
        /// All watchlists of an account.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<WatchlistGet[]> GetWatchlistsForSingleAccounts(string accountId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Replace watchlist for a specific account. This method does not verify that the symbol or asset type are valid.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> ReplaceWatchlist(string accountId, WatchlistPut watchlist, CancellationToken cancellationToken = default);
        /// <summary>
        /// <para>
        /// Partially update watchlist for a specific account: change watchlist name, add to the beginning/end of a watchlist, update or delete items in a watchlist. This method does not verify that the symbol or asset type are valid.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> UpdateWatchlist(string accountId, WatchlistPut watchlist, CancellationToken cancellationToken = default);

    }
}
