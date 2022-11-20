using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ConditionalTriggerCanceOrder : PlaceOrder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderType"></param>
        /// <param name="price"></param>
        /// <param name="session"></param>
        /// <param name="duration"></param>
        /// <param name="orderStrategyType"></param>
        /// <param name="orderLegCollections"></param>
        /// <param name="childOrderStrategies"></param>
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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("childOrderStrategies")]
        public ConditionalCancelOrder[] ChildOrderStrategies { get; set; }
    }
}
