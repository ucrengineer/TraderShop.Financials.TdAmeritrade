using Newtonsoft.Json;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.Models;

/// <summary>
///
/// </summary>
public class Instrument
{
    /// <summary>
    ///
    /// </summary>
    public string Cusip { get; set; } = string.Empty;
    /// <summary>
    ///
    /// </summary>
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    ///
    /// </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary>
    ///
    /// </summary>
    public string Exchange { get; set; } = string.Empty;
    /// <summary>
    ///
    /// </summary>
    public string AssetType { get; set; } = string.Empty;

    /// <summary>
    ///
    /// </summary>
    [JsonProperty("fundamental")]
    public Fundamentals Fundamentals { get; set; } = new Fundamentals();

}

/// <summary>
///
/// </summary>
public class Fundamentals
{
    /// <summary>
    ///
    /// </summary>
    public string Symbol { get; set; } = string.Empty;
    /// <summary>
    ///
    /// </summary>
    public double High52 { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double Low52 { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double DividendAmount { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double DividendYield { get; set; }
    /// <summary>
    ///
    /// </summary>
    public string DividendDate { get; set; } = string.Empty;
    /// <summary>
    ///
    /// </summary>
    public double PeRatio { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double PegRatio { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double PbRatio { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double PrRatio { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double PcfRatio { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double GrossMarginTTM { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double GrossMarginMRQ { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double NetProfitMarginTTM { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double NetProfitMarginMRQ { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double OperatingMarginTTM { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double OperatingMarginMRQ { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double ReturnOnEquity { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double ReturnOnAssets { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double ReturnOnInvestment { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double QuickRatio { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double CurrentRatio { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double InterestCoverage { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double TotalDebtToCapital { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double LtDebtToEquity { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double TotalDebtToEquity { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double EpsTTM { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double EpsChangePercentTTM { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double EpsChangeYear { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double EpsChange { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double RevChangeYear { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double RevChangeTTM { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double RevChangeIn { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double SharesOutstanding { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double MarketCapFloat { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double MarketCap { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double BookValuePerShare { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double ShortIntToFloat { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double ShortIntDayToCover { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double DivGrowthRate3Year { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double DividendPayAmount { get; set; }
    /// <summary>
    ///
    /// </summary>
    public string DividendPayDate { get; set; } = string.Empty;
    /// <summary>
    ///
    /// </summary>
    public double Beta { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double Vol1DayAvg { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double Vol10DayAvg { get; set; }
    /// <summary>
    ///
    /// </summary>
    public double Vol3MonthAvg { get; set; }
}