namespace TraderShop.Financials.TdAmeritrade.UserInfo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserPrinciple
    {
        /// <summary>
        /// 
        /// </summary>
        public string AuthToken { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserCdDomainId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string PrimaryAccountId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime TokenExpirationTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccessLevel { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public bool StalePassowrd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StreamerInfo StreamerInfo { get; set; } = new StreamerInfo();
        /// <summary>
        /// 
        /// </summary>
        public string ProfessionalStatus { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public Quotes Quotes { get; set; } = new Quotes();
        /// <summary>
        /// 
        /// </summary>
        public SubscriptionKey StreamerSubscriptionKeys { get; set; } = new SubscriptionKey();
        /// <summary>
        /// 
        /// </summary>
        public Account Account { get; set; } = new Account();
    }
    /// <summary>
    /// 
    /// </summary>
    public class Account
    {
        /// <summary>
        /// 
        /// </summary>
        public string AccountId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AccountCdDomainId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Company { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Segment { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public object SurrogateIds { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public Preferences Preferences { get; set; } = new Preferences();
        /// <summary>
        /// 
        /// </summary>
        public string Acl { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public Authorizations Authorizations { get; set; } = new Authorizations();
    }
    /// <summary>
    /// 
    /// </summary>
    public class Authorizations
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Apex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool LevelTwoQuotes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool StockTrading { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool MarginTrading { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool StreamingNews { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OptionTradingLevel { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public bool StreamerAccess { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool AdvancedMargin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ScottradeAccount { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Quotes
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsNyseDelayed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsNasdaqDelayed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsOpraDelayed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAmexDelayed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCmeDelayed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsIceDelayed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsForexDelayed { get; set; }

    }
    /// <summary>
    /// 
    /// </summary>
    public class StreamerInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string StreamerBinaryUrl { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string StreamerSocketUrl { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public DateTime TokenTimestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserGroup { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AccessLevel { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Acl { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; } = string.Empty;
    }
}
