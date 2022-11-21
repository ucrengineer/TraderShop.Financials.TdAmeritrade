using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeWatchlistProvider : BaseTdAmeritradeProvider, ITdAmeritradeWatchlistProvider
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="errorHandler"></param>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        public TdAmeritradeWatchlistProvider(
            IErrorHandler errorHandler,
            HttpClient httpClient,
            ITdAmeritradeAuthService authService)
            : base(authService, httpClient, errorHandler) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="watchlist"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> CreateWatchlist(string accountId, CreatedWatchlist watchlist, CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}{accountId}/watchlists";

            return await PostAsync<CreatedWatchlist>(uri, watchlist, cancellationToken);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="watchlistId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> DeleteWatchlist(string accountId, string watchlistId, CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}{accountId}/watchlists/{watchlistId}";

            return await DeleteAsync(uri, cancellationToken);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="watchlistId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestedWatchlist> GetWatchlist(string accountId, string watchlistId, CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}{accountId}/watchlists/{watchlistId}";

            var watchlist = await GetAsync<RequestedWatchlist>(uri, cancellationToken);

            return watchlist;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestedWatchlist[]> GetWatchlistsForMultipleAccounts(CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}watchlists";

            var watchlists = await GetAsync<RequestedWatchlist[]>(uri, cancellationToken);

            return watchlists;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestedWatchlist[]> GetWatchlistsForSingleAccounts(string accountId, CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}{accountId}/watchlists";

            var watchlists = await GetAsync<RequestedWatchlist[]>(uri, cancellationToken);

            return watchlists;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="watchlist"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> ReplaceWatchlist(string accountId, ReplacementWatchlist watchlist, CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}{accountId}/watchlists/{watchlist.WatchlistId}";

            return await PutAsync<ReplacementWatchlist>(uri, watchlist, cancellationToken);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="watchlist"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> UpdateWatchlist(string accountId, UpdatedWatchlist watchlist, CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}{accountId}/watchlists/{watchlist.WatchlistId}";

            return await PatchAsync<UpdatedWatchlist>(uri, watchlist, cancellationToken);
        }
    }
}
