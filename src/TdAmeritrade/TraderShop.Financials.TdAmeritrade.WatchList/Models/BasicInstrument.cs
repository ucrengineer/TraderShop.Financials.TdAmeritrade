using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Watchlist.Models
{
    public class BasicInstrument
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; } = string.Empty;
        /// <summary>
        /// <list type="bullet">
        /// <item><description>EQUITY</description></item>
        /// <item><description>OPTION</description></item>
        /// <item><description>MUTUAL_FUND</description></item>
        /// <item><description>FIXED_INCOME</description></item>
        /// <item><description>INDEX</description></item>
        /// </list>
        /// </summary>
        [JsonProperty("assetType")]
        public string AssetType { get; set; } = string.Empty;
    }
}
