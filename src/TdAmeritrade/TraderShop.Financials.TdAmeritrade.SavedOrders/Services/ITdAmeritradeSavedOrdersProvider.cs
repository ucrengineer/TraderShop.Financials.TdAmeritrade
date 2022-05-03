using TraderShop.Financials.TdAmeritrade.SavedOrders.Models;

namespace TraderShop.Financials.TdAmeritrade.SavedOrders.Services
{
    public interface ITdAmeritradeSavedOrdersProvider
    {
        /// <summary>
        /// Specific saved order by its ID, for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="savedOrderId"></param>
        /// <returns></returns>
        Task<SavedOrder> GetSavedOrder(string accountId, string savedOrderId);

        /// <summary>
        /// Saved orders for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<SavedOrder[]> GetSavedOrdersByAccountId(string accountId);
    }
}
