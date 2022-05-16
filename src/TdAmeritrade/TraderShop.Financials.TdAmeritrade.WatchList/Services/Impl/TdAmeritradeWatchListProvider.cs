using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Watchlist.Models;

namespace TraderShop.Financials.TdAmeritrade.Watchlist.Services.Impl
{
    public class TdAmeritradeWatchlistProvider : ITdAmeritradeWatchlistProvider
    {
        public readonly IErrorHandler _errorHandler;
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;

        public TdAmeritradeWatchlistProvider(IErrorHandler errorHandler, HttpClient httpClient, ITdAmeritradeAuthService authService)
        {
            _errorHandler = errorHandler;
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<int> CreateWatchlist(string accountId, WatchlistPost watchlist, CancellationToken cancellationToken = default)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId }, new string[] { "accountId" });

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var watchlistJson = JsonConvert.SerializeObject(watchlist);

            var content = new StringContent(watchlistJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
        }

        public async Task<int> DeleteWatchlist(string accountId, string watchlistId, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists/{watchlistId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.DeleteAsync(uri, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
        }

        public async Task<WatchlistGet> GetWatchlist(string accountId, string watchlistId, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists/{watchlistId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var watchlist = JsonConvert.DeserializeObject<WatchlistGet>(responseObject);

            return watchlist;
        }

        public async Task<WatchlistGet[]> GetWatchlistsForMultipleAccounts(CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}watchlists").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var watchlists = JsonConvert.DeserializeObject<WatchlistGet[]>(responseObject);

            return watchlists;
        }

        public async Task<WatchlistGet[]> GetWatchlistsForSingleAccounts(string accountId, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var watchlists = JsonConvert.DeserializeObject<WatchlistGet[]>(responseObject);

            return watchlists;
        }

        public async Task<int> ReplaceWatchlist(string accountId, WatchlistPut watchlist, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/watchlists/{watchlist.WatchlistId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var watchlistJson = JsonConvert.SerializeObject(watchlist);

            var content = new StringContent(watchlistJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
        }

        public async Task<int> UpdateWatchlist(string accountId, WatchlistPut watchlist, CancellationToken cancellationToken = default)
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
