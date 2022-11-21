namespace TraderShop.Financials.TdAmeritrade.UserInfo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class SubscriptionKey
    {
        /// <summary>
        /// 
        /// </summary>
        public Key[]? Keys { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Key
    {
        /// <summary>
        /// 
        /// </summary>
        public string key { get; set; } = string.Empty;
    }
}
