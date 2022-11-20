using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Quotes.Models;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeQuotesProvider : ITdAmeritradeQuotesProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IErrorHandler _errorHandler;
        private readonly ITdAmeritradeAuthService _authService;

        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        /// <param name="authService"></param>
        public TdAmeritradeQuotesProvider(HttpClient httpClient, IErrorHandler errorHandler, ITdAmeritradeAuthService authService)
        {

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
           


            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="symbol"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> GetQuote<T>(string symbol, CancellationToken cancellationToken = default) where T : Quote
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{symbol}/quotes").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var quote = JsonConvert.DeserializeObject<T>(responseObject);

            return quote;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Quote[]> GetQuotes(string[] symbols, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}/quotes").ToString();

            var query = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", symbols)
            };

            uri = QueryHelpers.AddQueryString(uri, query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var quotesResult = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseObject);

            if (quotesResult is null)
                throw new ArgumentNullException(nameof(quotesResult));

            var quotes = new Quote[0];

            foreach (var symbol in symbols)
            {
                var temp = JsonConvert.DeserializeObject<Quote>(quotesResult[symbol].ToString());

                quotes = quotes.Append
                    (temp?.AssetType switch
                    {
                        "FUTURE" => JsonConvert.DeserializeObject<Future>(quotesResult[symbol].ToString()),
                        "EQUITY" => JsonConvert.DeserializeObject<Equity>(quotesResult[symbol].ToString()),
                        "ETF" => JsonConvert.DeserializeObject<Equity>(quotesResult[symbol].ToString()),
                        "FOREX" => JsonConvert.DeserializeObject<Forex>(quotesResult[symbol].ToString()),
                        "OPTION" => JsonConvert.DeserializeObject<Option>(quotesResult[symbol].ToString()),
                        "INDEX" => JsonConvert.DeserializeObject<Models.Index>(quotesResult[symbol].ToString()),
                        "FUTURE_OPTION" => JsonConvert.DeserializeObject<FutureOptions>(quotesResult[symbol].ToString()),
                        "MUTUTAL_FUND" => JsonConvert.DeserializeObject<MutualFund>(quotesResult[symbol].ToString()),
                        _ => JsonConvert.DeserializeObject<Quote>(quotesResult[symbol].ToString()),
                    } ?? new Quote()
                    ).ToArray();
            }
            return quotes;
        }
    }
}
