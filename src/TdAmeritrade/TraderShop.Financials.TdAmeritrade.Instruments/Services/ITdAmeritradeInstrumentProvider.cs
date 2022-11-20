using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Instruments.Models;

namespace TraderShop.Financials.TdAmeritrade.Instruments.Services
{
    /// <summary>
    /// [A-Za-z.]*
    /// symbol-regex
    /// for equity only
    /// https://www.tdameritrade.com/investment-products/futures-trading.html
    /// for futures
    /// https://www.tdameritrade.com/investment-products/forex-trading.html
    /// for forex
    /// </summary>
    public interface ITdAmeritradeInstrumentProvider
    {
        /// <summary>
        /// Get a single instrument that matches symbol input
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Instrument> GetInstrument(string symbol, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get instruments with projection parameters
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="projection"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Instrument[]> GetInstruments(string symbol, Projection projection, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Instrument[]> GetAllFuturesInstruments(CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Instrument[]> GetAllForexInstruments(CancellationToken cancellationToken = default);
    }
}
