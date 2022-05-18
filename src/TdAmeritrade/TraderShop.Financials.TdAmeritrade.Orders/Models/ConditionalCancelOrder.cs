using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// <para>
    /// <b>Example</b> : Sell 2 shares of XYZ at a Limit price of $45.97 and Sell 2 shares of XYZ with a Stop Limit order where the stop price is $37.03 and limit is $37.00.  Both orders are sent at the same time.  When one order fills, the other order is immediately cancelled.  Both orders are good for the Day. Also known as an OCO order.
    /// </para>
    /// <see href="https://developer.tdameritrade.com/content/place-order-samples"/>
    /// </summary>
    public class ConditionalCancelOrder
    {
        public ConditionalCancelOrder(string orderStrategyType,
            OrderQuery[] childOrderStrategies)
        {
            OrderStrategyType = orderStrategyType;
            ChildOrderStrategies = childOrderStrategies;
        }

        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }

        [JsonProperty("childOrderStrategies")]
        public OrderQuery[] ChildOrderStrategies { get; set; }
    }
}
