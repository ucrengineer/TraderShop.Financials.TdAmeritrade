using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Movers.Models;

namespace TraderShop.Financials.TdAmeritrade.Movers.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class TdAmeritradeMoverProvider : ITdAmeritradeMoverProvider
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly HttpClient _httpClient;
        /// <summary>
        /// 
        /// </summary>
        public readonly ITdAmeritradeAuthService _authService;
        /// <summary>
        /// 
        /// </summary>
        public readonly IErrorHandler _errorHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradeMoverProvider(HttpClient httpClient, ITdAmeritradeAuthService authService, IErrorHandler errorHandler)
        {

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
           


            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moverQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mover[]> GetMovers(MoverQuery moverQuery, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{moverQuery.IndexSymbol}/movers").ToString();

            var query = new Dictionary<string, string>
            {
                ["direction"] = moverQuery.Direction.ToString(),
                ["change"] = moverQuery.Change.ToString(),
            };

            uri = QueryHelpers.AddQueryString(uri, query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var movers = JsonConvert.DeserializeObject<Mover[]>(responseObject);

            return movers;
        }
    }
}
