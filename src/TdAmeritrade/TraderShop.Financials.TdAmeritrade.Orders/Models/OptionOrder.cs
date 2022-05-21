using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// <see href="https://developer.tdameritrade.com/content/place-order-samples"/>
    /// </summary>
    public class OptionOrder : PlaceOrder
    {
        public OptionOrder(
            string? complexOrderStrategyType,
            string orderType,
            double price,
            string session,
            string duration,
            string orderStrategyType,
            OrderLegCollection[] orderLegCollections) : base(
                orderType,
                price,
                session,
                duration,
                orderStrategyType,
                orderLegCollections)
        {
            ComplexOrderStrategyType = complexOrderStrategyType;
        }
        [JsonProperty("complexOrderStrategyType")]
        public string? ComplexOrderStrategyType { get; set; }
    }
}
