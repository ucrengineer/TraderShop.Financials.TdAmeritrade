namespace TraderShop.Financials.TdAmeritrade.UserInfo.Models
{
    public class Preferences
    {
        public bool ExpressTrading { get; set; }
        public bool DirectOptionsRouting { get; set; }
        public bool DirectEquityRouting { get; set; }
        public string DefaultEquityOrderLegInstruction { get; set; } = string.Empty;
        public string DefaultEquityOrderType { get; set; } = string.Empty;
        public string DefaultEquityOrderPriceLinkType { get; set; } = string.Empty;
        public string DefaultEquityOrderDuration { get; set; } = string.Empty;
        public string DefaultEquityOrderMarketSession { get; set; } = string.Empty;
        public double DefaultEquityQuantity { get; set; }
        public string MutualFundTaxLotMethod { get; set; } = string.Empty;
        public string OptionTaxLotMethod { get; set; } = string.Empty;
        public string EquityTaxLotMethod { get; set; } = string.Empty;
        public string DefaultAdvancedToolLaunch { get; set; } = string.Empty;
        public string AuthTokenTimeout { get; set; } = string.Empty;
    }
}
