using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.SavedOrders.Models;

namespace TraderShop.Financials.TdAmeritrade.SavedOrders.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class TdAmeritradeSavedOrdersProvider : ITdAmeritradeSavedOrdersProvider
    {
        private readonly ITdAmeritradeAuthService _authService;
        private readonly HttpClient _httpClient;
        private readonly IErrorHandler _errorHandler;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tdAmeritradeAuthService"></param>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradeSavedOrdersProvider(ITdAmeritradeAuthService tdAmeritradeAuthService, HttpClient httpClient, IErrorHandler errorHandler)
        {
            _authService = tdAmeritradeAuthService;

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
           


            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="savedOrderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SavedOrder> GetSavedOrder(string accountId, string savedOrderId, CancellationToken cancellationToken)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/savedorders/{savedOrderId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var savedOrderRoot = JsonConvert.DeserializeObject<SavedOrderRoot>(responseObject);

            return savedOrderRoot.SavedOrder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SavedOrder[]> GetSavedOrdersByAccountId(string accountId, CancellationToken cancellationToken)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/savedorders").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var savedOrderRoot = JsonConvert.DeserializeObject<SavedOrderRoot[]>(responseObject);

            var savedOrders = new SavedOrder[savedOrderRoot.Length];

            for (var i = 0; i < savedOrderRoot.Length; i++)
            {
                savedOrders[i] = savedOrderRoot[i].SavedOrder;
            }

            return savedOrders;
        }
    }
}
