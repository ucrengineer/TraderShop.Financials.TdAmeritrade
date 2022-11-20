namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.Models
{
    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// 
        /// </summary>
        ALL,
        /// <summary>
        /// 
        /// </summary>
        TRADE,
        /// <summary>
        /// 
        /// </summary>
        BUY_ONLY,
        /// <summary>
        /// 
        /// </summary>
        SELL_ONLY,
        /// <summary>
        /// 
        /// </summary>
        CASH_IN_OR_CASH_OUT,
        /// <summary>
        /// 
        /// </summary>
        CHECKING,
        /// <summary>
        /// 
        /// </summary>
        DIVIDEND,
        /// <summary>
        /// 
        /// </summary>
        INTEREST,
        /// <summary>
        /// 
        /// </summary>
        OTHER,
        /// <summary>
        /// 
        /// </summary>
        ADVISOR_FEES
    }
}
