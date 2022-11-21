namespace TraderShop.Financials.TdAmeritrade.Abstractions.Options
{
    /// <summary>
    /// 
    /// </summary>
    public class TdAmeritradeOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public string client_id { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string refresh_token { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string redirect_uri { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string account_number { get; set; } = string.Empty;
    }
}