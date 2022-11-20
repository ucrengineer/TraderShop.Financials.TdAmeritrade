using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomOptionOrder : IBaseOrder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderStrategyType"></param>
        /// <param name="orderType"></param>
        /// <param name="complexOrderStrategyType"></param>
        /// <param name="duration"></param>
        /// <param name="session"></param>
        /// <param name="orderLegCollection"></param>
        public CustomOptionOrder(
            string orderStrategyType,
            string orderType,
            string? complexOrderStrategyType,
            string duration,
            string session,
            OrderLegCollection[] orderLegCollection)
        {
            OrderStrategyType = orderStrategyType;
            OrderType = orderType;
            ComplexOrderStrategyType = complexOrderStrategyType ?? "CUSTOM";
            Duration = duration;
            Session = session;
            OrderLegCollection = orderLegCollection;
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("orderType")]
        public string OrderType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("complexOrderStrategyType")]
        public string ComplexOrderStrategyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("session")]
        public string Session { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("orderLegCollection")]
        public OrderLegCollection[] OrderLegCollection { get; set; }
    }
}
