using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.SavedOrders.Models;

namespace TraderShop.Financials.TdAmeritrade.SavedOrders.Services.Impl
{
    public class TdAmeritradeSavedOrdersProvider : ITdAmeritradeSavedOrdersProvider
    {
        private readonly ITdAmeritradeAuthService _authService;
        private readonly HttpClient _httpClient;
        private TdAmeritradeOptions _tdAmeritradeOptions;

        public TdAmeritradeSavedOrdersProvider(ITdAmeritradeAuthService tdAmeritradeAuthService, HttpClient httpClient, IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions)
        {
            _authService = tdAmeritradeAuthService;
            _httpClient = httpClient;
            _tdAmeritradeOptions = tdAmeritradeOptions.CurrentValue;
            tdAmeritradeOptions.OnChange(x => _tdAmeritradeOptions = x);

        }
        async Task<SavedOrder> ITdAmeritradeSavedOrdersProvider.GetSavedOrder(string accountId, string savedOrderId)
        {
            await _authService.SetAccessToken();

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/savedorders/{savedOrderId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tdAmeritradeOptions.access_token);

            var response = await _httpClient.GetAsync(uri);

            var responseObject = await response.Content.ReadAsStringAsync();

            var savedOrderRoot = JsonConvert.DeserializeObject<SavedOrderRoot>(responseObject);

            return savedOrderRoot.SavedOrder;
        }

        async Task<SavedOrder[]> ITdAmeritradeSavedOrdersProvider.GetSavedOrdersByAccountId(string accountId)
        {
            await _authService.SetAccessToken();

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/savedorders").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tdAmeritradeOptions.access_token);

            var response = await _httpClient.GetAsync(uri);

            var responseObject = await response.Content.ReadAsStringAsync();

            var savedOrderRoot = JsonConvert.DeserializeObject<SavedOrderRoot[]>(responseObject);

            var savedOrders = new SavedOrder[savedOrderRoot.Length];

            for (var i = 0; i < savedOrderRoot.Length; i++)
            {
                savedOrders[i] = savedOrderRoot[i].SavedOrder;
            }

            return savedOrders;
        }
    }
}
