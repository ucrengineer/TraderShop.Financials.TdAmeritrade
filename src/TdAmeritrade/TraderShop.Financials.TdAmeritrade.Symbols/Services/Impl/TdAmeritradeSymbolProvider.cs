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
        /// <summary>
        /// returns a single instrument.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<Instrument> GetInstrument(string symbol)
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

            var responseObject = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(responseObject);

            return instrument?.Values.FirstOrDefault() ?? new Instrument();

        }
        /// <summary>
        /// Default will result in all equities returned.
        /// If array of symbols are provided, instruments will be returned.
        /// </summary>
        /// <param name="symbols"></param>
        /// <returns></returns>
        public async Task<IList<Instrument>> GetInstruments(string[]? symbols = null)
        {
            await _authService.SetAccessToken();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tdAmeritradeOptions.access_token);

            var query = new Dictionary<string, string>();

            var uri = string.Empty;

            query = symbols switch
            {
                null => new Dictionary<string, string>
                {
                    ["symbol"] = "[A-Za-z.]*",
                    ["projection"] = Projection.SymbolRegex
                },
                _ => new Dictionary<string, string>
                {
                    ["symbol"] = string.Join(",", symbols).ToString(),
                    ["projection"] = Projection.SymbolSearch
                }
            };

            uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            var response = await _httpClient.GetAsync(uri);

            var responseObject = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(responseObject);

            return instrument?.ToList().Select(x => x.Value).ToList() ?? new List<Instrument>();
        }
        /// <summary>
        /// Returns all of continuous futures markets
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Instrument>> GetAllFuturesInstruments()
        {
            await _authService.SetAccessToken();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tdAmeritradeOptions.access_token);

            var query = new Dictionary<string, string>();

            var uri = string.Empty;

            query = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", Futures.Symbols),
                ["projection"] = Projection.SymbolSearch
            };


            uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            var response = await _httpClient.GetAsync(uri);

            var responseObject = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(responseObject);

            return instrument?.ToList().Select(x => x.Value).ToList() ?? new List<Instrument>();
        }

        public Task<IList<Instrument>> GetAllForexInstruments()
        {
            throw new NotImplementedException();
        }
    }
}
