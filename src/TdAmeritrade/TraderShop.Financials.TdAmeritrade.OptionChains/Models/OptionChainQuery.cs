namespace TraderShop.Financials.TdAmeritrade.OptionChains.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class OptionChainQuery
    {
        /// <summary>
        /// Enter one symbol
        /// </summary>
        public string Symbol { get; set; } = String.Empty;
        /// <summary>
        /// Type of contracts to return in the chain. Can be CALL, PUT, or ALL. Default is ALL.
        /// </summary>
        public Contract ContractType { get; set; }
        /// <summary>
        /// The number of strikes to return above and below the at-the-money price.
        /// </summary>
        public double? StrikeCount { get; set; }
        /// <summary>
        /// Include quotes for options in the option chain. Can be TRUE or FALSE. Default is FALSE.
        /// </summary>
        public bool IncludeQuotes { get; set; }
        /// <summary>
        /// <para>
        /// Passing a value returns a Strategy Chain. Possible values are SINGLE, ANALYTICAL (allows use of the volatility, underlyingPrice, interestRate, and daysToExpiration params to calculate theoretical values), COVERED, VERTICAL, CALENDAR, STRANGLE, STRADDLE, BUTTERFLY, CONDOR, DIAGONAL, COLLAR, or ROLL. Default is SINGLE.
        /// </para>
        /// </summary>
        public Strategy Strategy { get; set; }
        /// <summary>
        /// Strike interval for spread strategy chains (see strategy param).
        /// </summary>
        public double Interval { get; set; }
        /// <summary>
        /// Provide a strike price to return options only at that strike price.
        /// </summary>
        public double? Strike { get; set; }
        /// <summary>
        /// <para>
        /// Returns options for the given range. Possible values are:
        /// <list type="bullet">
        /// <item><description>ITM: In-The-Money</description></item>
        /// <item><description>NTM: Near-the-money</description></item>
        /// <item><description>OTM: Out-of-the-money</description></item>
        /// <item><description>SAK: Strikes Above Markety</description></item>
        /// <item><description>SNK: Strikes Near Market</description></item>
        /// <item><description>ALL: All Strikes</description></item>
        /// </list>
        /// </para>
        /// </summary>
        public Range Range { get; set; }
        /// <summary>
        /// 'Only return expirations after this date. For strategies, expiration refers to the nearest term expiration in the strategy
        /// </summary>
        public DateTime FromDate { get; set; } = DateTime.Now.AddYears(-1);
        /// <summary>
        /// 'Only return expirations before this date. For strategies, expiration refers to the nearest term expiration in the strategy.
        /// </summary>
        public DateTime ToDate { get; set; } = DateTime.Now.AddYears(20);
        /// <summary>
        /// Volatility to use in calculations. Applies only to ANALYTICAL strategy chains (see strategy param).
        /// </summary>
        public double Volatility { get; set; }
        /// <summary>
        /// Underlying price to use in calculations. Applies only to ANALYTICAL strategy chains (see strategy param).
        /// </summary>
        public double UnderlyingPrice { get; set; }
        /// <summary>
        /// Interest rate to use in calculations. Applies only to ANALYTICAL strategy chains (see strategy param).
        /// </summary>
        public double InterestRate { get; set; }
        /// <summary>
        /// Days to expiration to use in calculations.Applies only to ANALYTICAL strategy chains(see strategy param).
        /// </summary>
        public double DaysToExpiration { get; set; }
        /// <summary>
        /// 'Return only options expiring in the specified month. Month is given in the three character format.
        /// Default is ALL.''
        /// </summary>
        public Month ExpMonth { get; set; }
        /// <summary>
        /// 'Type of contracts to return. Possible values are:
        /// <list type="bullet">
        /// <item><description>S: Standard contracts</description></item>
        /// <item><description>NS: Non-standard contracts</description></item>
        /// <item><description>ALL: All contracts</description></item>
        /// </list>
        /// Default is All.
        /// </summary>
        public OptionType OptionType { get; set; }


    }
    /// <summary>
    /// 
    /// </summary>
    public enum Contract
    {
        /// <summary>
        /// 
        /// </summary>
        ALL,
        /// <summary>
        /// 
        /// </summary>
        CALL,
        /// <summary>
        /// 
        /// </summary>
        PUT
    }
    /// <summary>
    /// 
    /// </summary>
    public enum Strategy
    {
        /// <summary>
        /// 
        /// </summary>
        SINGLE,
        /// <summary>
        /// 
        /// </summary>
        ANALYTICAL,
        /// <summary>
        /// 
        /// </summary>
        COVERED,
        /// <summary>
        /// 
        /// </summary>
        VERTICAL,
        /// <summary>
        /// 
        /// </summary>
        CALENDAR,
        /// <summary>
        /// 
        /// </summary>
        STRANGLE,
        /// <summary>
        /// 
        /// </summary>
        STRADDLE,
        /// <summary>
        /// 
        /// </summary>
        BUTTERFLY,
        /// <summary>
        /// 
        /// </summary>
        CONDOR,
        /// <summary>
        /// 
        /// </summary>
        DIAGONAL,
        /// <summary>
        /// 
        /// </summary>
        COLLAR,
        /// <summary>
        /// 
        /// </summary>
        ROLL
    }
    /// <summary>
    /// 
    /// </summary>
    public enum Range
    {
        /// <summary>
        /// 
        /// </summary>
        ALL,
        /// <summary>
        /// 
        /// </summary>
        ITM,
        /// <summary>
        /// 
        /// </summary>
        NTM,
        /// <summary>
        /// 
        /// </summary>
        OTM,
        /// <summary>
        /// 
        /// </summary>
        SAK,
        /// <summary>
        /// 
        /// </summary>
        SBK,
        /// <summary>
        /// 
        /// </summary>
        SNK
    }
    /// <summary>
    /// 
    /// </summary>
    public enum Month
    {
        /// <summary>
        /// 
        /// </summary>
        ALL,
        /// <summary>
        /// 
        /// </summary>
        JAN,
        /// <summary>
        /// 
        /// </summary>
        FEB,
        /// <summary>
        /// 
        /// </summary>
        MAR,
        /// <summary>
        /// 
        /// </summary>
        APR,
        /// <summary>
        /// 
        /// </summary>
        MAY,
        /// <summary>
        /// 
        /// </summary>
        JUN,
        /// <summary>
        /// 
        /// </summary>
        JUL,
        /// <summary>
        /// 
        /// </summary>
        AUG,
        /// <summary>
        /// 
        /// </summary>
        SEP,
        /// <summary>
        /// 
        /// </summary>
        OCT,
        /// <summary>
        /// 
        /// </summary>
        NOV,
        /// <summary>
        /// 
        /// </summary>
        DEC
    }
    /// <summary>
    /// 
    /// </summary>
    public enum OptionType
    {
        /// <summary>
        /// 
        /// </summary>
        ALL,
        /// <summary>
        /// 
        /// </summary>
        S,
        /// <summary>
        /// 
        /// </summary>
        NS
    }
}
