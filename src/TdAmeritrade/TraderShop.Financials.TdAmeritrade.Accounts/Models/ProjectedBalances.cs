namespace TraderShop.Financials.TdAmeritrade.Accounts.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProjectedBalances
    {
        /// <summary>
        /// 
        /// </summary>
        public double AvailableFunds { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double AvailableFundsNonMarginableTrade { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double BuyingPower { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double DayTradingBuyingPower { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double DayTradingBuyingPowerCall { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double MaintenanceCall { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double RegTCall { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsInCall { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double StockBuyingPower { get; set; }
    }
}
