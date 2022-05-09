using TraderShop.Financials.TdAmeritrade.Quotes.Models;

namespace TraderShop.Financials.TdAmeritrade.Quotes.Services
{
    public interface ITdAmeritradeQuotesProvider
    {
        /// <summary>
        /// <para>
        /// Get quote for a symbol.
        /// Currently no support for :
        /// <list type="bullet">
        /// <item><description>futures</description></item>
        /// <item><description>forex</description></item>
        /// </list>
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="quoteType"></param>
        /// <returns></returns>
        Task<T> GetQuote<T>(string symbol, CancellationToken cancellationToken = default) where T : Quote;

        Task<Quote[]> GetQuotes(string[] symbols, CancellationToken cancellationToken = default);
    }
}
