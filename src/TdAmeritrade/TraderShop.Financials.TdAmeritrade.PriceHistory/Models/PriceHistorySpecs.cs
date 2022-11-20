using Ardalis.SmartEnum;

namespace TraderShop.Financials.TdAmeritrade.PriceHistory.Models;
/// <summary>
/// 
/// </summary>
public class PriceHistorySpecs
{
    /// <summary>
    /// The type of period to show. Default is <b>day</b>.
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// day
    /// </description>
    /// </item>
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
    public PeriodType PeriodType { get; set; } = PeriodType.Year;

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
    public FrequencyType FrequecyType { get; set; } = FrequencyType.Daily;
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
/// <summary>
/// <list type="bullet">
/// <item><description>day = 0</description></item>
/// <item><description>month = 1</description></item>
/// <item><description>year = 2</description></item>
/// <item><description>ytd = 3</description></item>
/// </list>
/// </summary>
public abstract class PeriodType : SmartEnum<PeriodType>
{
    /// <summary>
    /// 
    /// </summary>
    public static readonly PeriodType Day = new DayType();

    /// <summary>
    /// 
    /// </summary>
    public static readonly PeriodType Month = new MonthType();

    /// <summary>
    /// 
    /// </summary>
    public static readonly PeriodType Year = new YearType();

    /// <summary>
    /// 
    /// </summary>
    public static readonly PeriodType Ytd = new YtdType();

    /// <summary>
    /// string name and enum int value
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public PeriodType(string name, int value) : base(name, value)
    {

    }

    private sealed class DayType : PeriodType
    {
        public DayType() : base("day", 0)
        {

        }
    }

    private sealed class MonthType : PeriodType
    {
        public MonthType() : base("month", 1)
        {

        }
    }
    private sealed class YearType : PeriodType
    {
        public YearType() : base("year", 2)
        {

        }
    }
    private sealed class YtdType : PeriodType
    {
        public YtdType() : base("ytd", 3)
        {

        }
    }
}

/// <summary>
/// <list type="bullet">
/// <item><description>minute = 0</description></item>
/// <item><description>daily = 1</description></item>
/// <item><description>weekly = 2</description></item>
/// <item><description>monthly = 3</description></item>
/// </list>
/// </summary>
public abstract class FrequencyType : SmartEnum<FrequencyType>
{
    /// <summary>
    /// 
    /// </summary>
    public static readonly FrequencyType Minute = new MinuteType();

    /// <summary>
    /// 
    /// </summary>
    public static readonly FrequencyType Daily = new DailyType();

    /// <summary>
    /// 
    /// </summary>
    public static readonly FrequencyType Weekly = new WeeklyType();

    /// <summary>
    /// 
    /// </summary>
    public static readonly FrequencyType Monthly = new MonthlyType();
    /// <summary>
    /// string name and enum int value
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public FrequencyType(string name, int value) : base(name, value)
    {
    }

    private sealed class MinuteType : FrequencyType
    {
        public MinuteType() : base("minute", 0)
        {

        }
    }

    private sealed class DailyType : FrequencyType
    {
        public DailyType() : base("daily", 1)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class WeeklyType : FrequencyType
    {
        /// <summary>
        /// 
        /// </summary>
        public WeeklyType() : base("weekly", 2)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class MonthlyType : FrequencyType
    {
        /// <summary>
        /// 
        /// </summary>
        public MonthlyType() : base("monthly", 3)
        {

        }
    }
}