using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    public class TrailingOrder : IBaseOrder
    {
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
        [JsonProperty("complexOrderStrategyType")]
        public string ComplexOrderStrategyType { get; set; }
        [JsonProperty("orderType")]
        public string OrderType { get; set; }
        [JsonProperty("session")]
        public string Session { get; set; }
        [JsonProperty("stopPriceLinkBasis")]
        public string StopPriceLinkBasis { get; set; }
        [JsonProperty("stopPriceLinkType")]
        public string StopPriceLinkType { get; set; }
        [JsonProperty("stopPriceOffset")]
        public double StopPriceOffset { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }
        [JsonProperty("orderLegCollection")]
        public OrderLegCollection[] OrderLegCollection { get; set; }
    }
}
