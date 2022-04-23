﻿using TraderShop.Financials.TdAmeritrade.Symbols.Models;

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
        Task<IList<Instrument>> GetEquityInstruments(string? symbol);

        Task<Instrument> GetEquityInstrument(string symbol);

        Task<IList<Instrument>> GetFutureInstruments(string? symbol);

        Task<Instrument> GetFutureInstrument(string symbol);

        Task<IList<Instrument>> GetForexInstruments(string? symbol);

        Task<Instrument> GetForexInstrument(string symbol);

    }
}
