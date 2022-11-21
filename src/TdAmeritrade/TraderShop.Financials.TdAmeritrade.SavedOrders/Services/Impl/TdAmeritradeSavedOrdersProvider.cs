using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.SavedOrders.Models;

namespace TraderShop.Financials.TdAmeritrade.SavedOrders.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeSavedOrdersProvider : BaseTdAmeritradeProvider, ITdAmeritradeSavedOrdersProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradeSavedOrdersProvider(
            ITdAmeritradeAuthService authService,
            HttpClient httpClient,
            IErrorHandler errorHandler)
        : base(
            authService, httpClient, errorHandler)
        { }
        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="savedOrderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SavedOrder> GetSavedOrder(string accountId, string savedOrderId, CancellationToken cancellationToken)
        {
            var uri = $"{baseUri}{accountId}/savedorders/{savedOrderId}";

            var savedOrderRoot = await GetAsync<SavedOrderRoot>(uri, cancellationToken);

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
            var uri = $"{baseUri}{accountId}/savedorders";

            var savedOrderRoot = await GetAsync<SavedOrderRoot[]>(uri, cancellationToken);

            var savedOrders = new List<SavedOrder>();

            foreach (var savedOrder in savedOrderRoot)
                savedOrders.Add(savedOrder.SavedOrder);

            return savedOrders.ToArray();
        }
    }
}
