namespace TraderShop.Financials.TdAmeritrade.Abstractions.Options
{
    // possibly add expires_in, token_recieved_time, and so forth in cache?
    // these are not exactly tdameritrade "options", these are more related to tokens
    public class TdAmeritradeOptions
    {
        public string auth_url { get; set; } = string.Empty;
        public string grant_type { get; set; } = string.Empty;
        public string client_id { get; set; } = string.Empty;

        public string access_token { get; set; } = string.Empty;
        public int expirers_in { get; set; }
        public string refresh_token { get; set; } = string.Empty;
        public string redirect_uri { get; set; } = string.Empty;
        public string account_number { get; set; } = string.Empty;
    }
}