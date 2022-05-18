namespace TraderShop.Financials.TdAmeritrade.Abstractions.Models;
public class Instrument
{
    public string Cusip { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Exchange { get; set; } = string.Empty;
    public string AssetType { get; set; } = string.Empty;

}
