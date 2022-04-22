namespace TraderShop.Financials.TdAmeritrade.Symbols.Models
{
    public class Instrument
    {
        public int Cuspid { get; set; }
        public string Symbol { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Exchange { get; set; } = string.Empty;

        public string AssetType { get; set; } = string.Empty;
    }
}
