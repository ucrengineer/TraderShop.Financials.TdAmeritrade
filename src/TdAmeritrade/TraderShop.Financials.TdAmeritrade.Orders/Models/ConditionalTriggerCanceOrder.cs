using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    public class ConditionalTriggerCanceOrder : PlaceOrder
    {
        public ConditionalTriggerCanceOrder(
            string orderType,
            double price,
            string session,
            string duration,
            string orderStrategyType,
            OrderLegCollection[] orderLegCollections,
            ConditionalCancelOrder[] childOrderStrategies) : base(
                orderType,
                price,
                session,
                duration,
                orderStrategyType,
                orderLegCollections)
        {
            ChildOrderStrategies = childOrderStrategies;
        }

        [JsonProperty("childOrderStrategies")]
        public ConditionalCancelOrder[] ChildOrderStrategies { get; set; }
    }
}
