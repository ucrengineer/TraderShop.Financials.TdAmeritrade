using TraderShop.Financials.TdAmeritrade.Quotes.Models;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Services
{
    public interface ITdAmeritradeQuotesProvider
    {
        /// <summary>
        /// <para>
        /// Get quote for a symbol.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="quoteType"></param>
        /// <returns></returns>
        Task<T> GetQuote<T>(string symbol, CancellationToken cancellationToken = default) where T : Quote;

        /// <summary>
        /// Get quote for one or more symbols.
        /// </summary>
        /// <param name="symbols"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Quote[]> GetQuotes(string[] symbols, CancellationToken cancellationToken = default);
    }
}
