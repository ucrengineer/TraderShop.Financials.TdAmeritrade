using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TrailingOrder : IBaseOrder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="complexOrderStrategyType"></param>
        /// <param name="orderType"></param>
        /// <param name="session"></param>
        /// <param name="stopPriceLinkBasis"></param>
        /// <param name="stopPriceLinkType"></param>
        /// <param name="stopPriceOffset"></param>
        /// <param name="duration"></param>
        /// <param name="orderStrategyType"></param>
        /// <param name="orderLegCollection"></param>
        public TrailingOrder(
            string? complexOrderStrategyType,
            string orderType,
            string session,
            string stopPriceLinkBasis,
            string stopPriceLinkType,
            double stopPriceOffset,
            string duration,
            string orderStrategyType,
            OrderLegCollection[] orderLegCollection)
        {
            ComplexOrderStrategyType = complexOrderStrategyType ?? "NONE";
            OrderType = orderType;
            Session = session;
            StopPriceLinkBasis = stopPriceLinkBasis;
            StopPriceLinkType = stopPriceLinkType;
            StopPriceOffset = stopPriceOffset;
            Duration = duration;
            OrderLegCollection = orderLegCollection;
            OrderStrategyType = orderStrategyType;
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("complexOrderStrategyType")]
        public string ComplexOrderStrategyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("orderType")]
        public string OrderType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("session")]
        public string Session { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("stopPriceLinkBasis")]
        public string StopPriceLinkBasis { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("stopPriceLinkType")]
        public string StopPriceLinkType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("stopPriceOffset")]
        public double StopPriceOffset { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("duration")]
        public string Duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("orderLegCollection")]
        public OrderLegCollection[] OrderLegCollection { get; set; }
    }
}
