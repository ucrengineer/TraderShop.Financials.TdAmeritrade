using Newtonsoft.Json;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;

namespace TraderShop.Financials.TdAmeritrade.WatchList.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WatchlistItem
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("quantity")]
        public double Quantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("averagePrice")]
        public double AveragePrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("commission")]
        public double Commission { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("purchasedDate")]
        public string PurchaseDate { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("instrument")]
        public BasicInstrument BasicInstrumnet { get; set; } = new BasicInstrument();
    }
}
