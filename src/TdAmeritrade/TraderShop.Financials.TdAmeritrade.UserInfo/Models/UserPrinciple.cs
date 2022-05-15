namespace TraderShop.Financials.TdAmeritrade.UserInfo.Models
{
    public class UserPrinciple
    {
        public string AuthToken { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string UserCdDomainId { get; set; } = string.Empty;
        public string PrimaryAccountId { get; set; } = string.Empty;
        public DateTime LastLoginTime { get; set; }
        public DateTime TokenExpirationTime { get; set; }
        public DateTime LoginTime { get; set; }
        public string AccessLevel { get; set; } = string.Empty;
        public bool StalePassowrd { get; set; }
        public StreamerInfo StreamerInfo { get; set; } = new StreamerInfo();
        public string ProfessionalStatus { get; set; } = string.Empty;
        public Quotes Quotes { get; set; } = new Quotes();
        public SubscriptionKey StreamerSubscriptionKeys { get; set; } = new SubscriptionKey();
        public Account Account { get; set; } = new Account();
    }
    public class Account
    {
        public string AccountId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string AccountCdDomainId { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Segment { get; set; } = string.Empty;
        public object SurrogateIds { get; set; } = string.Empty;
        public Preferences Preferences { get; set; } = new Preferences();
        public string Acl { get; set; } = string.Empty;
        public Authorizations Authorizations { get; set; } = new Authorizations();
    }
    public class Authorizations
    {
        public bool Apex { get; set; }
        public bool LevelTwoQuotes { get; set; }

        public bool StockTrading { get; set; }
        public bool MarginTrading { get; set; }
        public bool StreamingNews { get; set; }
        public string OptionTradingLevel { get; set; } = string.Empty;
        public bool StreamerAccess { get; set; }
        public bool AdvancedMargin { get; set; }
        public bool ScottradeAccount { get; set; }
    }
    public class Quotes
    {
        public bool IsNyseDelayed { get; set; }
        public bool IsNasdaqDelayed { get; set; }
        public bool IsOpraDelayed { get; set; }
        public bool IsAmexDelayed { get; set; }
        public bool IsCmeDelayed { get; set; }
        public bool IsIceDelayed { get; set; }
        public bool IsForexDelayed { get; set; }

    }
    public class StreamerInfo
    {
        public string StreamerBinaryUrl { get; set; } = string.Empty;
        public string StreamerSocketUrl { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime TokenTimestamp { get; set; }
        public string UserGroup { get; set; } = string.Empty;
        public string AccessLevel { get; set; } = string.Empty;
        public string Acl { get; set; } = string.Empty;
        public string AppId { get; set; } = string.Empty;
    }
}
