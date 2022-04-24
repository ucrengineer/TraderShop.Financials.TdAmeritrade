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
        Task<Instrument> GetInstrument(string symbol);

        Task<IList<Instrument>> GetInstruments(string[]? symbol = null);

        Task<IList<Instrument>> GetAllFuturesInstruments();

        Task<IList<Instrument>> GetAllForexInstruments();
    }
}
