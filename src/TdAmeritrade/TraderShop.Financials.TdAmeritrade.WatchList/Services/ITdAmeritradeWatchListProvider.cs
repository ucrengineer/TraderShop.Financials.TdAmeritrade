using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Services
{
    public interface ITdAmeritradeWatchlistProvider
    {
        /// <summary>
        /// Create watchlist for specific account.This method does not verify that the symbol or asset type are valid.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CreateWatchlist(string accountId, CreatedWatchlist watchlist, CancellationToken cancellationToken = default);
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
        Task<RequestedWatchlist> GetWatchlist(string accountId, string watchlistId, CancellationToken cancellationToken = default);
        /// <summary>
        /// All watchlists for all of the user's linked accounts.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RequestedWatchlist[]> GetWatchlistsForMultipleAccounts(CancellationToken cancellationToken = default);
        /// <summary>
        /// All watchlists of an account.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<RequestedWatchlist[]> GetWatchlistsForSingleAccounts(string accountId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Replace watchlist for a specific account. This method does not verify that the symbol or asset type are valid.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> ReplaceWatchlist(string accountId, ReplacementWatchlist watchlist, CancellationToken cancellationToken = default);
        /// <summary>
        /// <para>
        /// Partially update watchlist for a specific account: change watchlist name, add to the beginning/end of a watchlist, update or delete items in a watchlist. This method does not verify that the symbol or asset type are valid.
        /// </para>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> UpdateWatchlist(string accountId, UpdatedWatchlist watchlist, CancellationToken cancellationToken = default);

    }
}
