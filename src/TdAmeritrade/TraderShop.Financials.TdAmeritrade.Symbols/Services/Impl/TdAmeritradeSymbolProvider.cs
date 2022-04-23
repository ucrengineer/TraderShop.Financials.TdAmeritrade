using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Symbols.Models;

namespace TraderShop.Financials.TdAmeritrade.Symbols.Services.Impl
{
    public class TdAmeritradeSymbolProvider : ITdAmeritradeSymbolProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;
        private TdAmeritradeOptions _tdAmeritradeOptions;

        public TdAmeritradeSymbolProvider(HttpClient httpClient, ITdAmeritradeAuthService tdAmeritradeAuthService, IOptionsMonitor<TdAmeritradeOptions> tdAmeritradeOptions)
        {
            _httpClient = httpClient;
            _authService = tdAmeritradeAuthService;
            _tdAmeritradeOptions = tdAmeritradeOptions.CurrentValue;
            tdAmeritradeOptions.OnChange(x => _tdAmeritradeOptions = x);
        }
        public async Task<Instrument> GetEquityInstrument(string symbol)
        {
            await _authService.SetAccessToken();

            var query = new Dictionary<string, string>
            {
                ["symbol"] = symbol,
                ["projection"] = Projection.SymbolSearch
            };

            var uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tdAmeritradeOptions.access_token);

            var response = await _httpClient.GetAsync(uri);

            var view = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(view);

            return instrument?.Values?.FirstOrDefault();

        }
        public Task<IList<Instrument>> GetEquityInstruments(string? symbol)
        {
            throw new NotImplementedException();
        }

        public Task<Instrument> GetForexInstrument(string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Instrument>> GetForexInstruments(string? symbol)
        {
            throw new NotImplementedException();
        }

        public Task<Instrument> GetFutureInstrument(string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Instrument>> GetFutureInstruments(string? symbol)
        {
            throw new NotImplementedException();
        }

    }
}
