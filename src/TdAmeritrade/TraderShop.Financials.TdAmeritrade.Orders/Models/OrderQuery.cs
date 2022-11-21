namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderQuery
    {
        /// <summary>
        /// The max number of orders to retrieve.
        /// </summary>
        public double MaxResults { get; set; }

        /// <summary>
        /// Specifies that no orders entered before this time should be returned. If 'fromEnteredTime' is not sent, the default 'fromEnteredTime` would be 30 days from the current day.
        /// </summary>
        public DateTime FromEnteredTime { get; set; } = DateTime.Now.AddDays(-30);

        /// <summary>
        /// Specifies that no orders entered after this time should be returned. If 'toEnteredTime' is not sent, the default `toEnteredTime` would be the current day.
        /// </summary>
        public DateTime ToEnteredTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Specifies that only orders of this status should be returned. Default is <b>ALL</b>
        /// <list type="bullet">
        /// <item><description>AWAITING_PARENT_ORDER</description></item>
        /// <item><description>AWAITING_CONDITION</description></item>
        /// <item><description>AWAITING_MANUAL_REVIEW</description></item>
        /// <item><description>ACCEPTED</description></item>
        /// <item><description>AWAITING_UR_OUT</description></item>
        /// <item><description>QUEUED</description></item>
        /// <item><description>PENDING_ACTIVATION</description></item>
        /// <item><description>QUEUED</description></item>
        /// <item><description>WORKING</description></item>
        /// <item><description>REJECTED</description></item>
        /// <item><description>PENDING_CANCEL</description></item>
        /// <item><description>CANCELED</description></item>
        /// <item><description>PENDING_REPLACE</description></item>
        /// <item><description>REPLACED</description></item>
        /// <item><description>FILLED</description></item>
        /// <item><description>EXPIRED</description></item>
        /// <item><description>EXPIRED</description></item>
        /// </list>
        /// </summary>
        public Status Status { get; set; } = Status.ALL;
    }

    /// <summary>
    /// 
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 
        /// </summary>
        ALL,
        /// <summary>
        /// 
        /// </summary>
        AWAITING_PARENT_ORDER,
        /// <summary>
        /// 
        /// </summary>
        AWAITING_CONDITION,
        /// <summary>
        /// 
        /// </summary>
        AWAITING_MANUAL_REVIEW,
        /// <summary>
        /// 
        /// </summary>
        ACCEPTED,
        /// <summary>
        /// 
        /// </summary>
        AWAITING_UR_OUT,
        /// <summary>
        /// 
        /// </summary>
        PENDING_ACTIVATION,
        /// <summary>
        /// 
        /// </summary>
        QUEUED,
        /// <summary>
        /// 
        /// </summary>
        WORKING,
        /// <summary>
        /// 
        /// </summary>
        REJECTED,
        /// <summary>
        /// 
        /// </summary>
        PENDING_CANCEL,
        /// <summary>
        /// 
        /// </summary>
        CANCELED,
        /// <summary>
        /// 
        /// </summary>
        PENDING_REPLACE,
        /// <summary>
        /// 
        /// </summary>
        REPLACED,
        /// <summary>
        /// 
        /// </summary>
        FILLED,
        /// <summary>
        /// 
        /// </summary>
        EXPIRED
    }
}
