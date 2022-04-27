namespace TraderShop.Financials.TdAmeritrade.Accounts.Models
{
    public class CurrentBalances
    {
        public double AccruedInterest { get; set; }
        public double CashBalance { get; set; }
        public double CashReceipts { get; set; }
        public double LongOptionMarketValue { get; set; }
        public double LiquidationValue { get; set; }
        public double LongMarketValue { get; set; }
        public double MoneyMarketFund { get; set; }
        public double Savings { get; set; }
        public double ShortMarketValue { get; set; }
        public double PendingDeposits { get; set; }
        public double AvailableFunds { get; set; }
        public double AvailableFundsNonMarginableTrade { get; set; }
        public double BuyingPower { get; set; }
        public double BuyingPowerNonMarginableTrade { get; set; }
        public double DayTradingBuyingPower { get; set; }
        public double Equity { get; set; }
        public double EquityPercentage { get; set; }
        public double LongMarginValue { get; set; }
        public double MaintenanceCall { get; set; }
        public double MaintenanceRequirement { get; set; }
        public double MarginBalance { get; set; }
        public double RegTCall { get; set; }
        public double ShortBalance { get; set; }
        public double ShortMarginValue { get; set; }
        public double ShortOptionMarketValue { get; set; }
        public double Sma { get; set; }

        public double MutualFundValue { get; set; }
        public double BondValue { get; set; }
    }
}
