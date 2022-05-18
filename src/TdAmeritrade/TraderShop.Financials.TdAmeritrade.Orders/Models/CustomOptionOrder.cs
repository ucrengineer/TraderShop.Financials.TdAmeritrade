using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    public class CustomOptionOrder : IBaseOrder
    {
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
        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }
        [JsonProperty("orderType")]
        public string OrderType { get; set; }
        [JsonProperty("complexOrderStrategyType")]
        public string ComplexOrderStrategyType { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("session")]
        public string Session { get; set; }
        [JsonProperty("orderLegCollection")]
        public OrderLegCollection[] OrderLegCollection { get; set; }
    }
}
