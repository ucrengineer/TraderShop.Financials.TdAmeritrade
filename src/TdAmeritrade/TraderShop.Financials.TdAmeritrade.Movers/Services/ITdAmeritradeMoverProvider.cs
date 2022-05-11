using TraderShop.Financials.TdAmeritrade.Movers.Models;

namespace TraderShop.Financials.TdAmeritrade.Movers.Services
{
    public interface ITdAmeritradeMoverProvider
    {
        /// <summary>
        /// Top 10 (up or down) movers by value or percent for a particular market
        /// </summary>
        /// <param name="moverQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Mover[]> GetMovers(MoverQuery moverQuery, CancellationToken cancellationToken = default);
    }
}
