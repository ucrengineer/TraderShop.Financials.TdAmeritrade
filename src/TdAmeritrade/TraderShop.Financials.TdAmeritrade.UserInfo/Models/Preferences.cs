using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.UserInfo.Models
{
    public class Preferences
    {
        [JsonProperty("expressTrading")]
        public bool ExpressTrading { get; set; }
        [JsonProperty("directOptionsRouting")]
        public bool DirectOptionsRouting { get; set; }
        [JsonProperty("directEquityRouting")]
        public bool DirectEquityRouting { get; set; }
        [JsonProperty("defaultEquityOrderLegInstruction")]
        public string DefaultEquityOrderLegInstruction { get; set; } = string.Empty;
        [JsonProperty("defaultEquityOrderType")]
        public string DefaultEquityOrderType { get; set; } = string.Empty;
        [JsonProperty("defaultEquityOrderPriceLinkType")]
        public string DefaultEquityOrderPriceLinkType { get; set; } = string.Empty;
        [JsonProperty("defaultEquityOrderDuration")]
        public string DefaultEquityOrderDuration { get; set; } = string.Empty;
        [JsonProperty("defaultEquityOrderMarketSession")]
        public string DefaultEquityOrderMarketSession { get; set; } = string.Empty;
        [JsonProperty("defaultEquityQuantity")]
        public double DefaultEquityQuantity { get; set; }
        [JsonProperty("mutualFundTaxLotMethod")]
        public string MutualFundTaxLotMethod { get; set; } = string.Empty;
        [JsonProperty("optionTaxLotMethod")]
        public string OptionTaxLotMethod { get; set; } = string.Empty;
        [JsonProperty("equityTaxLotMethod")]
        public string EquityTaxLotMethod { get; set; } = string.Empty;
        [JsonProperty("defaultAdvancedToolLaunch")]
        public string DefaultAdvancedToolLaunch { get; set; } = string.Empty;
        [JsonProperty("authTokenTimeout")]
        public string AuthTokenTimeout { get; set; } = string.Empty;
    }
}
