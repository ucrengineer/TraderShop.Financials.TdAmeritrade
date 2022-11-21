using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.UserInfo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Preferences
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expressTrading")]
        public bool ExpressTrading { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("directOptionsRouting")]
        public bool DirectOptionsRouting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("directEquityRouting")]
        public bool DirectEquityRouting { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultEquityOrderLegInstruction")]
        public string DefaultEquityOrderLegInstruction { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultEquityOrderType")]
        public string DefaultEquityOrderType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultEquityOrderPriceLinkType")]
        public string DefaultEquityOrderPriceLinkType { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultEquityOrderDuration")]
        public string DefaultEquityOrderDuration { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultEquityOrderMarketSession")]
        public string DefaultEquityOrderMarketSession { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultEquityQuantity")]
        public double DefaultEquityQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("mutualFundTaxLotMethod")]
        public string MutualFundTaxLotMethod { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("optionTaxLotMethod")]
        public string OptionTaxLotMethod { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("equityTaxLotMethod")]
        public string EquityTaxLotMethod { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("defaultAdvancedToolLaunch")]
        public string DefaultAdvancedToolLaunch { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("authTokenTimeout")]
        public string AuthTokenTimeout { get; set; } = string.Empty;
    }
}
