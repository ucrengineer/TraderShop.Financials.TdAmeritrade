using Newtonsoft.Json;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// <see href="https://developer.tdameritrade.com/content/place-order-samples"/>
    /// </summary>
    public class PlaceOrder : IBaseOrder
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
        [JsonProperty("price")]
        public double Price { get; set; }
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

    /// <summary>
    /// 
    /// </summary>
    public class OrderLegCollection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="instruction"></param>
        /// <param name="quantity"></param>
        /// <param name="symbol"></param>
        /// <param name="assetType"></param>
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

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("instruction")]
        public string Instruction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("quantity")]
        public double Quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("instrument")]
        public BasicInstrument Instrument { get; set; }

    }
}
