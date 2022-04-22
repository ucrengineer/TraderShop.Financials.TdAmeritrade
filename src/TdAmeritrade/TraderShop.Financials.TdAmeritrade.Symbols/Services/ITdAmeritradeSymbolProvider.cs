using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Symbols.Models;

namespace TraderShop.Financials.TdAmeritrade.Symbols.Services
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
    public interface ITdAmeritradeSymbolProvider
    {
        Task<IList<Instrument>> GetEquityInstruments(Projection projection, string symbol);

        Task<Instrument> GetEquityInstrument(Projection projection, string symbol);

        Task<IList<Instrument>> GetFutureInstruments(Projection projection, string symbol);

        Task<Instrument> GetFutureInstrument(Projection projection, string symbol);

        Task<IList<Instrument>> GetForexInstruments(Projection projection, string symbol);

        Task<Instrument> GetForexInstrument(Projection projection, string symbol);

    }
}
