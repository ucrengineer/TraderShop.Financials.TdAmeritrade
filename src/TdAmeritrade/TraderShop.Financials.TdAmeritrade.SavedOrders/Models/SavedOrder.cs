using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.SavedOrders.Models
{

    public class SavedOrder : Order
    {
        public double SavedOrderId { get; set; }
        public string SavedTime { get; set; } = string.Empty;
    }

    public class SavedOrderRoot
    {
        public SavedOrder SavedOrder { get; set; } = new SavedOrder();
    }
}
