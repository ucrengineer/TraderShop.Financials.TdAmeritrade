using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.Services.Impl
{
    public class TdAmeritradeClientService : ITdAmeritradeClientService
    {
        private readonly HttpClient _httpClient;
        TdAmeritradeOptions _tdAmeritradeOptions;


        public TdAmeritradeClientService(HttpClient httpClient, IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions)
        {
            _httpClient = httpClient;
            _tdAmeritradeOptions = tdAmeritradeOptions.CurrentValue;
        }

        public async Task<PostAccessTokenResponse> GetAccessToken()
        {
            var PostAccessTokenRequest = _httpClient.BaseAddress + "oauth2/token";


            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type",_tdAmeritradeOptions.grant_type),
                new KeyValuePair<string, string>("refresh_token",_tdAmeritradeOptions.refresh_token),
                new KeyValuePair<string, string>("client_id",_tdAmeritradeOptions.client_id)
            });

            var response = await _httpClient.PostAsync(PostAccessTokenRequest, content);


            if (response.IsSuccessStatusCode)
            {
                var stringResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PostAccessTokenResponse>(stringResult) ?? new PostAccessTokenResponse() { access_token = await response.Content.ReadAsStringAsync() };
            }
            return new PostAccessTokenResponse() { access_token = await response.Content.ReadAsStringAsync() };
        }
    }
}
