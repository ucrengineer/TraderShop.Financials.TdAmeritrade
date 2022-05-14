namespace TraderShop.Financials.TdAmeritrade.MarketHours.Models
{
    /// <summary>
    /// Query parameters for MarketHours endpoint.
    /// </summary>
    public class MarketHoursQuery
    {
        /// <summary>
        /// The markets for which you're requesting market hours, comma-separated. Valid markets are EQUITY, OPTION, FUTURE, BOND, or FOREX.
        /// </summary>
        public string[] Markets { get; set; } = new string[] { "FUTURE" };

        /// <summary>
        /// The date for which market hours information is requested.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
