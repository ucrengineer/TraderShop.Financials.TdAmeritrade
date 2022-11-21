using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Orders.Models;

namespace TraderShop.Financials.TdAmeritrade.Orders.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeOrdersProvider : BaseTdAmeritradeProvider, ITdAmeritradeOrdersProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="errorHandler"></param>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        public TdAmeritradeOrdersProvider(
            IErrorHandler errorHandler,
            HttpClient httpClient,
            ITdAmeritradeAuthService authService)
            : base(authService, httpClient, errorHandler) { }
        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="OrderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Abstractions.Models.Order> GetOrder(string accountId, string OrderId, CancellationToken cancellationToken)
        {
            var uri = $"{baseUri}{accountId}/orders/{OrderId}";

            var Order = await GetAsync<Abstractions.Models.Order>(uri, cancellationToken);

            return Order;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="orderQuery"></param>
        /// <returns></returns>
        public async Task<Abstractions.Models.Order[]> GetOrdersByPath(string accountId, CancellationToken cancellationToken, OrderQuery? orderQuery)
        {
            var uri = new Uri($"{baseUri}{accountId}/orders").ToString();

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

            var Orders = await GetAsync<Abstractions.Models.Order[]>(uri, cancellationToken);

            return Orders;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="accountId"></param>
        /// <param name="orderQuery"></param>
        /// <returns></returns>
        public async Task<Abstractions.Models.Order[]> GetOrdersByQuery(CancellationToken cancellationToken, string? accountId, OrderQuery? orderQuery)
        {
            var uri = $"{baseUri.Split("/accounts").FirstOrDefault()}/orders";

            if (orderQuery != null)
            {
                var query = new Dictionary<string, string>
                {
                    ["accountId"] = accountId ?? string.Empty,
                    ["maxResults"] = orderQuery.MaxResults.ToString(),
                    ["fromEnteredTime"] = orderQuery.FromEnteredTime.ToString("yyyy-MM-dd"),
                    ["toEnteredTime"] = orderQuery.ToEnteredTime.ToString("yyyy-MM-dd"),
                    ["status"] = orderQuery.Status == Status.ALL ? string.Empty : orderQuery.Status.ToString()
                };

                uri = QueryHelpers.AddQueryString(uri, query);
            }

            var Orders = await GetAsync<Abstractions.Models.Order[]>(uri, cancellationToken);

            return Orders;
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="accountId"></param>
        /// <param name="order"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> PlaceOrder<T>(string accountId, T order, CancellationToken cancellationToken) where T : IBaseOrder
        {
            var uri = $"{baseUri}{accountId}/orders";

            return await PostAsync<T>(uri, order, cancellationToken);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="accountId"></param>
        /// <param name="orderId"></param>
        /// <param name="order"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> ReplaceOrder<T>(string accountId, string orderId, T order, CancellationToken cancellationToken) where T : IBaseOrder
        {
            var uri = $"{baseUri}{accountId}/orders/{orderId}";

            return await PutAsync(uri, order, cancellationToken);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> CancelOrder(string accountId, string orderId, CancellationToken cancellationToken)
        {
            var uri = $"{baseUri}{accountId}/orders/{orderId}";

            return await DeleteAsync(uri, cancellationToken);
        }
    }
}
