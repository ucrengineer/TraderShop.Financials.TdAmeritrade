using TraderShop.Financials.TdAmeritrade.Abstractions.Models;
using TraderShop.Financials.TdAmeritrade.Symbols.Models;

namespace TraderShop.Financials.TdAmeritrade.Symbols.Services.Impl
{
    public class TdAmeritradeSymbolProvider : ITdAmeritradeSymbolProvider
    {
        public Task<Instrument> GetEquityInstrument(Projection projection, string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Instrument>> GetEquityInstruments(Projection projection, string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<Instrument> GetForexInstrument(Projection projection, string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Instrument>> GetForexInstruments(Projection projection, string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<Instrument> GetFutureInstrument(Projection projection, string symbol)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Instrument>> GetFutureInstruments(Projection projection, string symbol)
        {
            throw new NotImplementedException();
        }
    }
}
