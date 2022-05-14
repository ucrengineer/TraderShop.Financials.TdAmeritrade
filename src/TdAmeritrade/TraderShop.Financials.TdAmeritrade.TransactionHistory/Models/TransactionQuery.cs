namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.Models
{
    public class TransactionQuery
    {
        /// <summary>
        /// Only transactions with the specified type will be returned.
        /// </summary>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Only transactions with the specified symbol will be returned.
        /// </summary>
        public string Symbol { get; set; } = string.Empty;

        /// <summary>
        /// Only transactions after the Start Date will be returned.
        /// Note: The maximum date range is one year.
        /// </summary>
        public DateTime StartDate { get; set; } = DateTime.Now.AddYears(-1);

        /// <summary>
        /// Only transactions before the End Date will be returned.
        /// Note: The maximum date range is one year.
        /// </summary>
        public DateTime EndDate { get; set; } = DateTime.Now;
    }

    public enum TransactionType
    {
        ALL,
        TRADE,
        BUY_ONLY,
        SELL_ONLY,
        CASH_IN_OR_CASH_OUT,
        CHECKING,
        DIVIDEND,
        INTEREST,
        OTHER,
        ADVISOR_FEES
    }
}
