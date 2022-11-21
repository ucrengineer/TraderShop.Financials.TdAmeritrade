
using Ardalis.SmartEnum;

namespace TraderShop.Financials.TdAmeritrade.Instruments.Models;
/// <summary>
/// 
/// </summary>
public abstract class Projection : SmartEnum<Projection>
{
    /// <summary>
    ///  Retrieve instrument data of a specific symbol or cusip
    /// </summary>
    public static readonly Projection SymbolSearch = new SymbolSearchType();

    /// <summary>
    /// Retrieve instrument data for all symbols matching regex.
    /// Example: symbol=XYZ.* will return all symbols beginning with XYZ
    /// </summary>
    public static readonly Projection SymbolRegex = new SymbolRegexType();

    /// <summary>
    /// Retrieve instrument data for instruments whose description contains the word supplied.
    /// Example: symbol=FakeCompany will return all instruments with FakeCompany in the description.
    /// </summary>
    public static readonly Projection DescSearch = new DescSearchType();

    /// <summary>
    /// Search description with full regex support.
    /// Example: symbol=XYZ.[A-C] returns all instruments whose descriptions contain a word beginning with XYZ followed by a character A through C.
    /// </summary>
    public static readonly Projection DescRegex = new DescRegexType();

    /// <summary>
    /// Returns fundamental data for a single instrument specified by exact symbol.'
    /// </summary>
    public static readonly Projection Fundamental = new FundamentalType();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public Projection(string name, int value) : base(name, value)
    {
    }

    private sealed class SymbolSearchType : Projection
    {
        public SymbolSearchType() : base("symbol-search", 0)
        {
        }
    }
    private sealed class SymbolRegexType : Projection
    {
        public SymbolRegexType() : base("symbol-regex", 1)
        {
        }
    }
    private sealed class DescSearchType : Projection
    {
        public DescSearchType() : base("desc-search", 2)
        {
        }
    }
    private sealed class DescRegexType : Projection
    {
        public DescRegexType() : base("desc-regex", 3)
        {
        }
    }
    private sealed class FundamentalType : Projection
    {
        public FundamentalType() : base("fundamental", 4)
        {
        }
    }
}