using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Orders.Models;

namespace TraderShop.Financials.TdAmeritrade.Orders.Services.Impl
{
    public class TdAmeritradeOrdersProvider : ITdAmeritradeOrdersProvider
    {
        public readonly IErrorHandler _errorHandler;
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;

        public TdAmeritradeOrdersProvider(
            IErrorHandler errorHandler,
            HttpClient httpClient,
            ITdAmeritradeAuthService authService)
        {
            _errorHandler = errorHandler;
            _httpClient = httpClient;
            _authService = authService;
        }
        public async Task<Abstractions.Models.Order> GetOrder(string accountId, string OrderId, CancellationToken cancellationToken)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders/{OrderId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var Order = JsonConvert.DeserializeObject<Abstractions.Models.Order>(responseObject);

            return Order;
        }

        public async Task<Abstractions.Models.Order[]> GetOrdersByPath(string accountId, CancellationToken cancellationToken, OrderQuery? orderQuery)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders").ToString();

            if (orderQuery != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["maxResults"] = orderQuery.MaxResults.ToString(),
                    ["fromEnteredTime"] = orderQuery.FromEnteredTime.ToString("yyyy-MM-dd"),
                    ["toEnteredTime"] = orderQuery.ToEnteredTime.ToString("yyyy-MM-dd"),
                    ["status"] = orderQuery.Status == Status.ALL ? "" : orderQuery.Status.ToString()
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var Orders = JsonConvert.DeserializeObject<Abstractions.Models.Order[]>(responseObject);

            return Orders;
        }

        public async Task<Abstractions.Models.Order[]> GetOrdersByQuery(CancellationToken cancellationToken, string? accountId, OrderQuery? orderQuery)
        {
            var uri = new Uri($"{_httpClient.BaseAddress.ToString().Split("/accounts").FirstOrDefault()}/orders").ToString();

            if (orderQuery != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["accountId"] = accountId ?? string.Empty,
                    ["maxResults"] = orderQuery.MaxResults.ToString(),
                    ["fromEnteredTime"] = orderQuery.FromEnteredTime.ToString("yyyy-MM-dd"),
                    ["toEnteredTime"] = orderQuery.ToEnteredTime.ToString("yyyy-MM-dd"),
                    ["status"] = orderQuery.Status.ToString()
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var Orders = JsonConvert.DeserializeObject<Abstractions.Models.Order[]>(responseObject);

            return Orders;
        }

        public async Task<int> PlaceOrder<T>(string accountId, T order, CancellationToken cancellationToken) where T : IBaseOrder
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var orderJson = JsonConvert.SerializeObject(order);

            var content = new StringContent(orderJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
        }

        public async Task<int> ReplaceOrder<T>(string accountId, string orderId, T order, CancellationToken cancellationToken) where T : IBaseOrder
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders/{orderId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var orderJson = JsonConvert.SerializeObject(order);

            var content = new StringContent(orderJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
        }

        public async Task<int> CancelOrder(string accountId, string orderId, CancellationToken cancellationToken)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders/{orderId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.DeleteAsync(uri, cancellationToken);

            await _errorHandler.CheckCommandErrorsAsync(response);

            return 0;
        }
    }
}
