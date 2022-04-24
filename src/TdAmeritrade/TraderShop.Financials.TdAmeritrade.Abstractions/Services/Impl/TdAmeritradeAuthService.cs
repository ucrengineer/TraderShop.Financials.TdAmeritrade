using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.Services.Impl
{
    public class TdAmeritradeAuthService : ITdAmeritradeAuthService
    {
        private readonly HttpClient _httpClient;
        private TdAmeritradeOptions _tdAmeritradeOptions;


        public TdAmeritradeAuthService(HttpClient httpClient, IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions)
        {
            _httpClient = httpClient;
            _tdAmeritradeOptions = tdAmeritradeOptions.CurrentValue;
            tdAmeritradeOptions.OnChange(x => _tdAmeritradeOptions = x);
        }

        public async Task<int> SetAccessToken()
        {

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type",_tdAmeritradeOptions.grant_type),
                new KeyValuePair<string, string>("refresh_token",_tdAmeritradeOptions.refresh_token),
                new KeyValuePair<string, string>("client_id",_tdAmeritradeOptions.client_id)
            });

            var response = await _httpClient.PostAsync(_tdAmeritradeOptions.auth_url, content);

            var result = JsonConvert.DeserializeObject<PostAccessTokenResponse>(await response.Content.ReadAsStringAsync()) ?? new PostAccessTokenResponse() { error = $"Response Status Code : {response.StatusCode}" };

            _tdAmeritradeOptions.access_token = result.access_token;
            return 0;
        }

        public Task<int> SetAuthToken()
        {
            throw new NotImplementedException();
        }
    }
}
