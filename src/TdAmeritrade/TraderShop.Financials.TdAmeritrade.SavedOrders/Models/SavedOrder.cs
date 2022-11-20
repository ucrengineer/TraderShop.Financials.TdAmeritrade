using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.SavedOrders.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class SavedOrder : Order
    {
        /// <summary>
        /// 
        /// </summary>
        public double SavedOrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SavedTime { get; set; } = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    public class SavedOrderRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public SavedOrder SavedOrder { get; set; } = new SavedOrder();
    }
}
