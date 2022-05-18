using Newtonsoft.Json;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// <see href="https://developer.tdameritrade.com/content/place-order-samples"/>
    /// </summary>
    public class PlaceOrder : IBaseOrder
    {

        public PlaceOrder(
            string orderType,
            double price,
            string session,
            string duration,
            string orderStrategyType,
            OrderLegCollection[] orderLegCollections
            )
        {
            OrderType = orderType;
            Session = session;
            Price = price;
            Duration = duration;
            OrderStrategyType = orderStrategyType;
            OrderLegCollection = orderLegCollections;
        }
        [JsonProperty("orderType")]
        public string OrderType { get; set; }
        [JsonProperty("session")]
        public string Session { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("duration")]
        public string Duration { get; set; }
        [JsonProperty("orderStrategyType")]
        public string OrderStrategyType { get; set; }
        [JsonProperty("orderLegCollection")]
        public OrderLegCollection[] OrderLegCollection { get; set; }
    }

    public class OrderLegCollection
    {
        public OrderLegCollection(
            string instruction,
            double quantity,
            string symbol,
            string assetType)
        {
            Instruction = instruction;
            Quantity = quantity;
            Instrument = new BasicInstrument()
            {
                Symbol = symbol,
                AssetType = assetType
            };
        }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }
        [JsonProperty("quantity")]
        public double Quantity { get; set; }
        [JsonProperty("instrument")]
        public BasicInstrument Instrument { get; set; }

    }
}
