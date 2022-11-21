using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Quotes.Models;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeQuotesProvider : BaseTdAmeritradeProvider, ITdAmeritradeQuotesProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        /// <param name="authService"></param>
        public TdAmeritradeQuotesProvider(HttpClient httpClient, IErrorHandler errorHandler, ITdAmeritradeAuthService authService) :
            base(
            authService, httpClient, errorHandler)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="symbol"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> GetQuote<T>(string symbol, CancellationToken cancellationToken = default) where T : Quote
        {
            var uri = $"{baseUri}{symbol}/quotes";

            var quote = await GetAsync<T>(uri, cancellationToken);

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
            var uri = new Uri($"{baseUri}/quotes").ToString();

            var query = new Dictionary<string, string>
            {
                ["symbol"] = string.Join(",", symbols)
            };

            uri = QueryHelpers.AddQueryString(uri, query);

            var quotesResult = await GetAsync<Dictionary<string, object>>(uri, cancellationToken);

            var quotes = new Quote[0];

            foreach (var symbol in symbols)
            {

                var temp = Deserialize<Quote>(quotesResult[symbol].ToString());

                quotes = quotes.Append
                    (temp.AssetType switch
                    {
                        "FUTURE" => Deserialize<Future>(quotesResult[symbol].ToString()),
                        "EQUITY" => Deserialize<Equity>(quotesResult[symbol].ToString()),
                        "ETF" => Deserialize<Equity>(quotesResult[symbol].ToString()),
                        "FOREX" => Deserialize<Forex>(quotesResult[symbol].ToString()),
                        "OPTION" => Deserialize<Option>(quotesResult[symbol].ToString()),
                        "INDEX" => Deserialize<Models.Index>(quotesResult[symbol].ToString()),
                        "FUTURE_OPTION" => Deserialize<FutureOptions>(quotesResult[symbol].ToString()),
                        "MUTUTAL_FUND" => Deserialize<MutualFund>(quotesResult[symbol].ToString()),
                        _ => Deserialize<Quote>(quotesResult[symbol].ToString()),
                    }
                    ).ToArray();
            }
            return quotes;
        }
    }
}
