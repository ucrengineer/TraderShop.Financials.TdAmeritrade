namespace TraderShop.Financials.TdAmeritrade.Accounts.Models
{
    public class SecuritiesAccount
    {
        public string Type { get; set; } = string.Empty;
        public string AccountId { get; set; } = string.Empty;
        public int RoundTrips { get; set; }
        public bool IsDayTrader { get; set; }

        public bool IsClosingOnlyRestricted { get; set; }
        public InitialBalances InitialBalances { get; set; } = new InitialBalances();

        public CurrentBalances CurrentBalances { get; set; } = new CurrentBalances();

        public ProjectedBalances ProjectedBalances { get; set; } = new ProjectedBalances();
    }

    public class SecuritiesAccountRoot
    {
        public SecuritiesAccount SecuritiesAccount { get; set; } = new SecuritiesAccount();
    }
}
