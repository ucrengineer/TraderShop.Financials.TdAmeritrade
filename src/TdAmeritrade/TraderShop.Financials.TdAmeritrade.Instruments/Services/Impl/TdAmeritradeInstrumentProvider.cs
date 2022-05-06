using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Instruments.Models;

namespace TraderShop.Financials.TdAmeritrade.Instruments.Services.Impl
{
    public class TdAmeritradeInstrumentProvider : ITdAmeritradeInstrumentProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ITdAmeritradeAuthService _authService;
        private readonly IErrorHandler _errorHandler;

        public TdAmeritradeInstrumentProvider(HttpClient httpClient, ITdAmeritradeAuthService tdAmeritradeAuthService, IErrorHandler errorHandler)
        {
            _httpClient = httpClient;
            _authService = tdAmeritradeAuthService;
            _errorHandler = errorHandler;
        }
        /// <summary>
        /// returns a single instrument.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public async Task<Instrument> GetInstrument(string symbol, CancellationToken cancellationToken)
        {
            var query = new Dictionary<string, string>
            {
                ["symbol"] = symbol,
                ["projection"] = Projection.SymbolSearch
            };

            var uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

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
        public async Task<IList<Instrument>> GetInstruments(CancellationToken cancellationToken, string[]? symbols = null)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

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

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(responseObject);

            return instrument?.ToList().Select(x => x.Value).ToList() ?? new List<Instrument>();
        }
        /// <summary>
        /// Returns all of continuous futures markets
        /// </summary>
        /// <returns></returns>
        public async Task<IList<Instrument>> GetAllFuturesInstruments(CancellationToken cancellationToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var query = new Dictionary<string, string>();

            var uri = string.Empty;

            query = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", Futures.Symbols),
                ["projection"] = Projection.SymbolSearch
            };


            uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(responseObject);

            return instrument?.ToList().Select(x => x.Value).ToList() ?? new List<Instrument>();
        }

        public Task<IList<Instrument>> GetAllForexInstruments(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
