using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
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
                ["projection"] = Projection.SymbolSearch.Name
            };

            var uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(responseObject);

            return instrument?.Values.FirstOrDefault() ?? new Instrument();

        }

        public async Task<Instrument[]> GetInstruments(string symbol, Projection projection, CancellationToken cancellationToken = default)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var query = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", symbol),
                ["projection"] = projection.Name
            };

            var uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(responseObject);

            return instrument?.ToList().Select(x => x.Value).ToArray() ?? new Instrument[0];
        }
        /// <summary>
        /// Returns all of continuous futures markets
        /// </summary>
        /// <returns></returns>
        public async Task<Instrument[]> GetAllFuturesInstruments(CancellationToken cancellationToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var query = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", Futures.Symbols),
                ["projection"] = Projection.SymbolSearch.Name
            };


            var uri = QueryHelpers.AddQueryString(_httpClient.BaseAddress?.ToString(), query);

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var instrument = JsonConvert.DeserializeObject<Dictionary<string, Instrument>>(responseObject);

            return instrument?.ToList().Select(x => x.Value).ToArray() ?? new Instrument[0];
        }


        public Task<Instrument[]> GetAllForexInstruments(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
