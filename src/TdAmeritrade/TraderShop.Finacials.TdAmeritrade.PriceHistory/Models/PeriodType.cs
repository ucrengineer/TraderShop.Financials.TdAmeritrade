namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.Models
{
    /// <summary>
    /// The type of period to show.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Day
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Month</description>
    /// </item>
    /// <item>
    /// <description>
    /// Year</description>
    /// </item>
    /// <item>
    /// <description>
    /// Ytd</description>
    /// </item>
    /// </list>
    /// </summary>
    public static class PeriodType
    {
        public static readonly string Day = "day";
        public static readonly string Month = "month";
        public static readonly string Year = "year";
        public static readonly string Ytd = "ytd";
    }
}
