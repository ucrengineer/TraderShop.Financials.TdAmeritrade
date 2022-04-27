namespace TraderShop.Financials.TdAmeritrade.Accounts.Models
{
    public class ProjectedBalances
    {
        public double AvailableFunds { get; set; }
        public double AvailableFundsNonMarginableTrade { get; set; }
        public double BuyingPower { get; set; }
        public double DayTradingBuyingPower { get; set; }
        public double DayTradingBuyingPowerCall { get; set; }
        public double MaintenanceCall { get; set; }
        public double RegTCall { get; set; }
        public bool IsInCall { get; set; }
        public double StockBuyingPower { get; set; }
    }
}
