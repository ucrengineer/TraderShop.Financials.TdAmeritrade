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
        Task<Instrument> GetInstrument(string symbol, CancellationToken cancellationToken = default);

        Task<IList<Instrument>> GetInstruments(CancellationToken cancellationToken = default, string[]? symbols = null);

        Task<IList<Instrument>> GetAllFuturesInstruments(CancellationToken cancellationToken = default);

        Task<IList<Instrument>> GetAllForexInstruments(CancellationToken cancellationToken = default);
    }
}
