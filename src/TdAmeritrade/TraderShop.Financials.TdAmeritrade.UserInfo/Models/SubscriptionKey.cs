namespace TraderShop.Financials.TdAmeritrade.UserInfo.Models
{
    public class SubscriptionKey
    {
        public Key[]? Keys { get; set; }
    }
    public class Key
    {
        public string key { get; set; } = string.Empty;
    }
}
