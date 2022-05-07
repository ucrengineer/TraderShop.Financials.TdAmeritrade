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
        public async Task<Order> GetOrder(string accountId, string OrderId, CancellationToken cancellationToken)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId, OrderId });

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders/{OrderId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var Order = JsonConvert.DeserializeObject<Order>(responseObject);

            return Order;
        }

        public async Task<Order[]> GetOrdersByPath(string accountId, CancellationToken cancellationToken, OrderQuery? orderQuery)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId });

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

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var Orders = JsonConvert.DeserializeObject<Order[]>(responseObject);

            return Orders;
        }

        public async Task<Order[]> GetOrdersByQuery(CancellationToken cancellationToken, string? accountId, OrderQuery? orderQuery)
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

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var Orders = JsonConvert.DeserializeObject<Order[]>(responseObject);

            return Orders;
        }

        public async Task<int> PlaceOrder(string accountId, object order, CancellationToken cancellationToken)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId });

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var orderJson = JsonConvert.SerializeObject(order);

            var content = new StringContent(orderJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content, cancellationToken);

            response.EnsureSuccessStatusCode();

            return 0;
        }

        public async Task<int> ReplaceOrder(string accountId, string orderId, object order, CancellationToken cancellationToken)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId, orderId });

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders/{orderId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var orderJson = JsonConvert.SerializeObject(order);

            var content = new StringContent(orderJson, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, content, cancellationToken);

            response.EnsureSuccessStatusCode();

            return 0;
        }

        public async Task<int> CancelOrder(string accountId, string orderId, CancellationToken cancellationToken)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId, orderId });

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/orders/{orderId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.DeleteAsync(uri, cancellationToken);

            response.EnsureSuccessStatusCode();

            return 0;
        }
    }
}
