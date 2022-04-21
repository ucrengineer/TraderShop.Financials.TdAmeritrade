namespace TraderShop.Financials.TdAmeritrade.Abstractions.Options
{
    public class TdAmeritradeOptions
    {
        public string url { get; set; }
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string refresh_token { get; set; }
        public string redirect_uri { get; set; }
    }
}