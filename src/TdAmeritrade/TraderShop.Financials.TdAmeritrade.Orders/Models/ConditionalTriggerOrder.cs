using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// <para><b>Example</b> : Buy 10 shares of XYZ at a Limit price of $34.97 good for the Day. Once filled, immediately submit an order to Sell 10 shares of XYZ with a Limit price of $42.03 good for the Day.  Also known as 1st Trigger Sequence.</para>
    /// </summary>
    public class ConditionalTriggerOrder : PlaceOrder
    {
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

        [JsonProperty("childOrderStrategies")]
        public PlaceOrder[] ChildOrderStrategies { get; set; }
    }

}
