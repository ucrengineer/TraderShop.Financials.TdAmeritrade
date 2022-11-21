using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TraderShop.Financials.Abstractions.Model;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeAuthService : ITdAmeritradeAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private TdAmeritradeOptions _tdAmeritradeOptions;
        private readonly IErrorHandler _errorHandler;


        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="memoryCache"></param>
        /// <param name="errorHandler"></param>
        /// <param name="tdAmeritradeOptions"></param>
        public TdAmeritradeAuthService(
            HttpClient httpClient,
            IMemoryCache memoryCache,
            IErrorHandler errorHandler,
            IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions)
        {

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _memoryCache = memoryCache;
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
            _tdAmeritradeOptions = tdAmeritradeOptions.CurrentValue;
            tdAmeritradeOptions.OnChange(x => _tdAmeritradeOptions = x);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<string> GetBearerToken(CancellationToken cancellationToken)
        {
            if (!_memoryCache.TryGetValue("tdAmeritrade-bearer", out Token? cacheValue))
            {
                var tokenResponse = await SetAccessToken(cancellationToken);

                cacheValue = new Token() { Value = tokenResponse.access_token, Expires_In = tokenResponse.expires_in };

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheValue.Expires_In));

                _memoryCache.Set("tdAmeritrade-bearer", cacheValue, cacheEntryOptions);
            }

            return cacheValue?.Value ?? throw new ArgumentNullException(nameof(Token));
        }

        private async Task<PostAccessTokenResponse> SetAccessToken(CancellationToken cancellationToken)
        {
            var content = new FormUrlEncodedContent(
                new[]
                    {
                            new KeyValuePair<string, string>("grant_type","refresh_token"),
                            new KeyValuePair<string, string>("refresh_token",_tdAmeritradeOptions.refresh_token),
                            new KeyValuePair<string, string>("client_id",_tdAmeritradeOptions.client_id)
                    });

            var response = await _httpClient.PostAsync(_httpClient.BaseAddress, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            var result = JsonConvert.DeserializeObject<PostAccessTokenResponse>(await response.Content.ReadAsStringAsync());

            if (result is null)
                throw new ArgumentNullException(nameof(PostAccessTokenResponse));

            return result;

        }
    }
}
