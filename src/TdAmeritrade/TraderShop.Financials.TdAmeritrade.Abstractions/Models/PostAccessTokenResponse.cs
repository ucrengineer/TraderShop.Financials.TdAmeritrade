namespace TraderShop.Financials.TdAmeritrade.Abstractions.Models
{
    /// <summary>
    /// Model for tdameritrade oAuth API
    /// </summary>
    public class PostAccessTokenResponse
    {
        /// <summary>
        /// <para>
        /// Set to offline to receive a refresh token on an authorization_code grant type request. Do not set to offline on a refresh_token grant type request.
        /// </para>
        /// </summary>
        public string access_token { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string token_type { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public int expires_in { get; set; }
        /// <summary>
        /// Required if using refresh token grant
        /// </summary>
        public string refresh_token { get; set; } = string.Empty;
        /// <summary>
        ///
        /// </summary>
        public string scope { get; set; } = string.Empty;

        /// <summary>
        ///
        /// </summary>
        public string error { get; set; } = string.Empty;
    }
}