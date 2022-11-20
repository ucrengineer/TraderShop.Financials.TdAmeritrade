namespace TraderShop.Financials.TdAmeritrade.Accounts.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SecuritiesAccount
    {
        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AccountId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public int RoundTrips { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDayTrader { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsClosingOnlyRestricted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public InitialBalances InitialBalances { get; set; } = new InitialBalances();

        /// <summary>
        /// 
        /// </summary>
        public CurrentBalances CurrentBalances { get; set; } = new CurrentBalances();

        /// <summary>
        /// 
        /// </summary>
        public ProjectedBalances ProjectedBalances { get; set; } = new ProjectedBalances();
    }

    /// <summary>
    /// 
    /// </summary>
    public class SecuritiesAccountRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public SecuritiesAccount SecuritiesAccount { get; set; } = new SecuritiesAccount();
    }
}
