namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.Models
{
    public class PriceHistorySpecs
    {
        /// <summary>
        /// Instrument symbol. Default is AAPL.
        /// </summary>
        public string Symbol { get; set; } = "AAPL";

        /// <summary>
        /// The type of period to show. Default is day.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// month
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// year</description>
        /// </item>
        /// <item>
        /// <description>
        /// ytd</description>
        /// </item>
        /// </list>
        /// </summary>
        public PeriodType PeriodType { get; set; } = PeriodType.year;

        /// <summary>
        /// The number of periods to show. Valid periods by periodType (defaults marked with an asterisk):
        /// <list type="table">
        /// <item>
        /// <term>day</term>
        /// <description>1, 2, 3, 4, 5, 10*</description>
        /// </item>
        /// <item>
        /// <term>month</term>
        /// <description>1*, 2, 3, 6</description></item>
        /// <item>
        /// <term>year</term>
        /// <description>1*, 2, 3, 5, 10, 15, 20</description>
        /// </item>
        /// <item>
        /// <term>ytd</term>
        /// <description>1*</description>
        /// </item>
        /// </list>
        /// </summary>
        public int Period { get; set; } = 1;

        /// <summary>
        /// The type of frequency with which a new candle is formed.
        /// Valid frequencyTypes by periodType (defaults marked with an asterisk):
        /// <list type="table">
        /// <item>
        /// <term>day</term>
        /// <description>minute*</description>
        /// </item>
        /// <item>
        /// <term>month</term>
        /// <description>daily, weekly*</description>
        /// </item>
        /// <item>
        /// <term>year</term>
        /// <description>daily, weekly, monthly*</description>
        /// </item>
        /// <item>
        /// <term>ytd</term>
        /// <description>daily, weekly*</description>
        /// </item></list>
        /// </summary>
        public FrequecyType FrequecyType { get; set; } = FrequecyType.daily;
        /// <summary>
        /// The number of the frequencyType to be included in each candle.
        /// Valid frequencies by frequencyType (defaults marked with an asterisk):
        /// <list type="table">
        /// <item>
        /// <term>minute</term>
        /// <description>1*, 5, 10, 15, 30</description>
        /// </item>
        /// <item>
        /// <term>daily</term>
        /// <description>1*</description>
        /// </item>
        /// <item>
        /// <term>weekly</term>
        /// <description>1*</description>
        /// </item>
        /// <item>
        /// <term>monthly</term>
        /// <description>1*</description>
        /// </item></list>
        /// </summary>
        public int Frequency { get; set; } = 1;
        /// <summary>
        /// End date as milliseconds since epoch.
        /// If startDate and endDate are provided, period should not be provided.
        /// Default is previous trading day.
        /// </summary>
        public DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now.AddDays(-1);

        /// <summary>
        /// Start date as milliseconds since epoch. If startDate and endDate are provided, period should not be provided.
        /// </summary>
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now.AddYears(-1);

        /// <summary>
        /// <b>true</b> to return <b>extended hours data</b>,<b>false</b> for <b>regular market hours</b> only.<b>Default</b>  is <b>true</b>.
        /// </summary>
        public bool NeedExtendedHoursData { get; set; } = true;

    }

    public enum PeriodType
    {
        day,
        month,
        year,
        ytd
    }

    public enum FrequecyType
    {
        minute,
        daily,
        weekly,
        monthly
    }
}
