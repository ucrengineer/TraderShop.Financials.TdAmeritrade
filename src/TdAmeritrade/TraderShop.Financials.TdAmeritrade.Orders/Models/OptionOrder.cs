using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// <see href="https://developer.tdameritrade.com/content/place-order-samples"/>
    /// </summary>
    public class OptionOrder : PlaceOrder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="complexOrderStrategyType"></param>
        /// <param name="orderType"></param>
        /// <param name="price"></param>
        /// <param name="session"></param>
        /// <param name="duration"></param>
        /// <param name="orderStrategyType"></param>
        /// <param name="orderLegCollections"></param>
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
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("complexOrderStrategyType")]
        public string? ComplexOrderStrategyType { get; set; }
    }
}
