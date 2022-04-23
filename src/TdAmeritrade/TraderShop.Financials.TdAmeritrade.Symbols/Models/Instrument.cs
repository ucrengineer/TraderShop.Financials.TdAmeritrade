namespace TraderShop.Financials.TdAmeritrade.Symbols.Models
{
    public class Instrument
    {
        public string Cusip { get; set; } = String.Empty;
        public string Symbol { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Exchange { get; set; } = string.Empty;

        public string AssetType { get; set; } = string.Empty;
    }
}
