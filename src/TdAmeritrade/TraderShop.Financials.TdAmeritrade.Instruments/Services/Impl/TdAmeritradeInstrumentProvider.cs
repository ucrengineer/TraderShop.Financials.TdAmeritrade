using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Instruments.Models;

namespace TraderShop.Financials.TdAmeritrade.Instruments.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeInstrumentProvider : BaseTdAmeritradeProvider, ITdAmeritradeInstrumentProvider
    {

        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradeInstrumentProvider(
            HttpClient httpClient,
            ITdAmeritradeAuthService authService,
            IErrorHandler errorHandler) : base(
                authService,
                httpClient,
                errorHandler)
        { }
        /// <summary>
        /// returns a single instrument.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Instrument> GetInstrument(string symbol, CancellationToken cancellationToken)
        {
            var query = new Dictionary<string, string>
            {
                ["symbol"] = symbol,
                ["projection"] = Projection.SymbolSearch.Name
            };

            var uri = QueryHelpers.AddQueryString(baseUri, query);

            var instrument = await GetAsync<Dictionary<string, Instrument>>(uri, cancellationToken);

            return instrument.Values.First();

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="projection"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Instrument[]> GetInstruments(string symbol, Projection projection, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", symbol),
                ["projection"] = projection.Name
            };

            var uri = QueryHelpers.AddQueryString(baseUri, query);

            var instrument = await GetAsync<Dictionary<string, Instrument>>(uri, cancellationToken);

            return instrument.ToList().Select(x => x.Value).ToArray();
        }
        /// <summary>
        /// Returns all of continuous futures markets
        /// </summary>
        /// <returns></returns>
        public async Task<Instrument[]> GetAllFuturesInstruments(CancellationToken cancellationToken)
        {
            var query = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", Futures.Symbols),
                ["projection"] = Projection.SymbolSearch.Name
            };


            var uri = QueryHelpers.AddQueryString(baseUri, query);

            var instrument = await GetAsync<Dictionary<string, Instrument>>(uri, cancellationToken);

            return instrument.ToList().Select(x => x.Value).ToArray();
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Instrument[]> GetAllForexInstruments(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
