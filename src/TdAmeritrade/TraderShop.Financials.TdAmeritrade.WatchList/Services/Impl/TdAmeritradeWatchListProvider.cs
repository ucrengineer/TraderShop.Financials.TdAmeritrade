using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.WatchList.Models;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class TdAmeritradeWatchlistProvider : ITdAmeritradeWatchlistProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IErrorHandler _errorHandler;
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorHandler"></param>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        public TdAmeritradeWatchlistProvider(IErrorHandler errorHandler, HttpClient httpClient, ITdAmeritradeAuthService authService)
        {
           


            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="watchlist"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> CreateWatchlist(string accountId, CreatedWatchlist watchlist, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var watchlistJson = JsonConvert.SerializeObject(watchlist);

            var content = new StringContent(watchlistJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
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
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists/{watchlistId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.DeleteAsync(uri, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
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
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists/{watchlistId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var watchlist = JsonConvert.DeserializeObject<RequestedWatchlist>(responseObject);

            return watchlist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestedWatchlist[]> GetWatchlistsForMultipleAccounts(CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}watchlists").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var watchlists = JsonConvert.DeserializeObject<RequestedWatchlist[]>(responseObject);

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
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var watchlists = JsonConvert.DeserializeObject<RequestedWatchlist[]>(responseObject);

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
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists/{watchlist.WatchlistId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var watchlistJson = JsonConvert.SerializeObject(watchlist);

            var content = new StringContent(watchlistJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
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
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists/{watchlist.WatchlistId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var watchlistJson = JsonConvert.SerializeObject(watchlist);

            var content = new StringContent(watchlistJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PatchAsync(uri, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
        }
    }
}
