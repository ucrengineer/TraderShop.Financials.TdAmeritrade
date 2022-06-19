namespace TraderShop.Financials.TdAmeritrade.Abstractions.Models;
public class Instrument
{
    public string Cusip { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Exchange { get; set; } = string.Empty;
    public string AssetType { get; set; } = string.Empty;

}

public class Fundamental
{
    public string Symbol { get; set; }
    public double High52 { get; set; }
    public double Low52 { get; set; }
    public decimal DividendAmount { get; set; }
    public decimal DividendYield { get; set; }
    public string DividendDate { get; set; }
    public decimal PeRatio { get; set; }
    public decimal PegRatio { get; set; }
    public decimal PbRatio { get; set; }
    public decimal PrRatio { get; set; }
    public decimal PcfRatio { get; set; }
    public decimal GrossMarginTTM { get; set; }
    public decimal GrossMarginMRQ { get; set; }
    public decimal ReturnOnEquity { get; set; }
    public decimal ReturnOnAssets { get; set; }
    public decimal ReturnOnInvestments { get; set; }
    public decimal QuickRatio { get; set; }
    public decimal CurrentRatio { get; set; }
    public decimal InterestCoverage { get; set; }
    public decimal TotalDebtToCapital { get; set; }
    public decimal LtDeptToEqutiy { get; set; }
}
