namespace TraderShop.Financials.TdAmeritrade.Abstractions.Options
{
    public class TdAmeritradeOptions
    {
        public string auth_url { get; set; } = string.Empty;
        public string client_id { get; set; } = string.Empty;
        public string refresh_token { get; set; } = string.Empty;
        public string redirect_uri { get; set; } = string.Empty;
        public string account_number { get; set; } = string.Empty;
    }
}