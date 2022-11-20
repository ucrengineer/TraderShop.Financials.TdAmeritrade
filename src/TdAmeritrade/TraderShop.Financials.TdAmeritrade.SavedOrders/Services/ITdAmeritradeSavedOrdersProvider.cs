using TraderShop.Financials.TdAmeritrade.SavedOrders.Models;

namespace TraderShop.Financials.TdAmeritrade.SavedOrders.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITdAmeritradeSavedOrdersProvider
    {
        /// <summary>
        /// Specific saved order by its ID, for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="savedOrderId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SavedOrder> GetSavedOrder(string accountId, string savedOrderId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Saved orders for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<SavedOrder[]> GetSavedOrdersByAccountId(string accountId, CancellationToken cancellationToken = default);
    }
}
