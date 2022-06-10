using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Movers.Models;

namespace TraderShop.Financials.TdAmeritrade.Movers.Services.Impl
{
    public class TdAmeritradeMoverProvider : ITdAmeritradeMoverProvider
    {
        public readonly HttpClient _httpClient;
        public readonly ITdAmeritradeAuthService _authService;
        public readonly IErrorHandler _errorHandler;

        public TdAmeritradeMoverProvider(HttpClient httpClient, ITdAmeritradeAuthService authService, IErrorHandler errorHandler)
        {
            _httpClient = httpClient;
            _authService = authService;
            _errorHandler = errorHandler;
        }

        public async Task<Mover[]> GetMovers(MoverQuery moverQuery, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{moverQuery.IndexSymbol}/movers").ToString();

            var query = new Dictionary<string, string>
            {
                ["direction"] = moverQuery.Direction.ToString(),
                ["change"] = moverQuery.Change.ToString(),
            };

            uri = QueryHelpers.AddQueryString(uri, query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var movers = JsonConvert.DeserializeObject<Mover[]>(responseObject);

            return movers;
        }
    }
}
