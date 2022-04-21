namespace TraderShop.Financials.TdAmeritrade.Abstractions.Models
{
    public class PostAccessTokenResponse
    {
        public string access_token { get; set; } = string.Empty;
        public string token_type { get; set; } = string.Empty;
        public int expires_in { get; set; }
        public string refresh_token { get; set; } = string.Empty;
        public string scope { get; set; } = string.Empty;

        public string error { get; set; } = string.Empty;
    }
}