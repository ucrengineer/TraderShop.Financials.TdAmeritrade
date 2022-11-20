using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// <para><b>Example</b> : Buy 10 shares of XYZ at a Limit price of $34.97 good for the Day. Once filled, immediately submit an order to Sell 10 shares of XYZ with a Limit price of $42.03 good for the Day.  Also known as 1st Trigger Sequence.</para>
    /// </summary>
    public class ConditionalTriggerOrder : PlaceOrder
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
        public ConditionalTriggerOrder(
            string orderType,
            double price,
            string session,
            string duration,
            string orderStrategyType,
            OrderLegCollection[] orderLegCollections,
            PlaceOrder[] childOrderStrategies) : base(
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
        public PlaceOrder[] ChildOrderStrategies { get; set; }
    }

}
