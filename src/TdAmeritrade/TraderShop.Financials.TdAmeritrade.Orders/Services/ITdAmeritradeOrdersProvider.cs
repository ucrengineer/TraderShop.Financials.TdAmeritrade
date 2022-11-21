using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Orders.Models;

namespace TraderShop.Financials.TdAmeritrade.Orders.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITdAmeritradeOrdersProvider
    {
        /// <summary>
        /// Get a specific order for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Order> GetOrder(string accountId, string orderId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Orders for a specific account.
        /// </summary>
        /// <returns></returns>
        Task<Order[]> GetOrdersByPath(string accountId, CancellationToken cancellationToken = default, OrderQuery? orderQuery = null);

        /// <summary>
        /// All orders for a specific account or, if account ID isn't specified, orders will be returned for all linked accounts.
        /// </summary>
        /// <returns></returns>
        Task<Order[]> GetOrdersByQuery(CancellationToken cancellationToken = default, string? accountId = null, OrderQuery? orderQuery = null);

        /// <summary>
        /// <para>Place an order for a specific account. Order throttle limits may apply.</para>
        /// <see href="https://developer.tdameritrade.com/content/place-order-samples">see official documentation</see>
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="order"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> PlaceOrder<T>(string accountId, T order, CancellationToken cancellationToken = default) where T : IBaseOrder;

        /// <summary>
        /// <para>Replace an existing order for an account.
        /// The existing order will be replaced by the new order.
        /// Once replaced, the old order will be canceled and a new order will be created.
        /// Order throttle limits may apply.
        /// </para>
        /// <see href="https://developer.tdameritrade.com/content/place-order-samples">see official documentation</see>
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="orderId"></param>
        /// <param name="order"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> ReplaceOrder<T>(string accountId, string orderId, T order, CancellationToken cancellationToken = default) where T : IBaseOrder;

        /// <summary>
        /// Cancel a specific order for a specific account. Order throttle limits may apply.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="orderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CancelOrder(string accountId, string orderId, CancellationToken cancellationToken = default);
    }
}
