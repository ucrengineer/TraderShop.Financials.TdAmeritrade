
namespace TraderShop.Financials.TdAmeritrade.Instruments.Models
{
    public static class Projection
    {
        /// <summary>
        ///  Retrieve instrument data of a specific symbol or cusip
        /// </summary>
        public static readonly string SymbolSearch = "symbol-search";

        /// <summary>
        /// Retrieve instrument data for all symbols matching regex.
        /// Example: symbol=XYZ.* will return all symbols beginning with XYZ
        /// </summary>
        public static readonly string SymbolRegex = "symbol-regex";

        /// <summary>
        /// Retrieve instrument data for instruments whose description contains the word supplied.
        /// Example: symbol=FakeCompany will return all instruments with FakeCompany in the description.
        /// </summary>
        public static readonly string DescSearch = "desc-search";

        /// <summary>
        /// Search description with full regex support.
        /// Example: symbol=XYZ.[A-C] returns all instruments whose descriptions contain a word beginning with XYZ followed by a character A through C.
        /// </summary>
        public static readonly string DescRegex = "desc-regex";

        /// <summary>
        /// Returns fundamental data for a single instrument specified by exact symbol.'
        /// </summary>
        public static readonly string Fundamental = "fundamental";

    }
}
