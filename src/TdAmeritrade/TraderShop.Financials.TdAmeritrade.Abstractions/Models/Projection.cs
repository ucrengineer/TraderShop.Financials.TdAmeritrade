using TraderShop.Financials.Abstractions;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.Models
{
    public class Projection : Enumeration
    {
        /// <summary>
        ///  Retrieve instrument data of a specific symbol or cusip
        /// </summary>
        public static Projection SymbolSearch = new(1, "symbol-search");

        /// <summary>
        /// Retrieve instrument data for all symbols matching regex.
        /// Example: symbol=XYZ.* will return all symbols beginning with XYZ
        /// </summary>
        public static Projection SymbolRegex = new(1, "symbol-regex");

        /// <summary>
        /// Retrieve instrument data for instruments whose description contains the word supplied.
        /// Example: symbol=FakeCompany will return all instruments with FakeCompany in the description.
        /// </summary>
        public static Projection DescSearch = new(1, "desc-search");

        /// <summary>
        /// Search description with full regex support.
        /// Example: symbol=XYZ.[A-C] returns all instruments whose descriptions contain a word beginning with XYZ followed by a character A through C.
        /// </summary>
        public static Projection DescRegex = new(1, "desc-regex");

        /// <summary>
        /// Returns fundamental data for a single instrument specified by exact symbol.'
        /// </summary>
        public static Projection Fundamental = new(1, "fundamental");


        public Projection(int id, string name) : base(id, name)
        {
        }
    }
}
