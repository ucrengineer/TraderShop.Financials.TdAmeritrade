namespace TraderShop.Financials.TdAmeritrade.Orders.Models
{
    public class OrderQuery
    {
        /// <summary>
        /// The max number of orders to retrieve.
        /// </summary>
        public double MaxResults { get; set; }

        /// <summary>
        /// Specifies that no orders entered before this time should be returned. If 'toEnteredTime' is not sent, the default `toEnteredTime` would be 30 days from the current day.
        /// </summary>
        public DateTime FromEnteredTime { get; set; } = DateTime.Now.AddDays(-30);

        /// <summary>
        /// Specifies that no orders entered after this time should be returned. If 'fromEnteredTime' is not sent, the default `fromEnteredTime` would be the current day.
        /// </summary>
        public DateTime ToEnteredTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Specifies that only orders of this status should be returned. Default is <b>FILLED</b>
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
        /// </list>
        /// </summary>
        /// </summary>
        public Status Status { get; set; } = Status.FILLED;
    }

    public enum Status
    {
        AWAITING_PARENT_ORDER,
        AWAITING_CONDITION,
        AWAITING_MANUAL_REVIEW,
        ACCEPTED,
        AWAITING_UR_OUT,
        PENDING_ACTIVATION,
        QUEUED,
        WORKING,
        REJECTED,
        PENDING_CANCEL,
        CANCELED,
        PENDING_REPLACE,
        REPLACED,
        FILLED,
        EXPIRED
    }
}
