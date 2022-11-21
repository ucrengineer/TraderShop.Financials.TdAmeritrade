using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Movers.Models;

namespace TraderShop.Financials.TdAmeritrade.Movers.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeMoverProvider : BaseTdAmeritradeProvider, ITdAmeritradeMoverProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="authService"></param>
        /// <param name="errorHandler"></param>
        public TdAmeritradeMoverProvider(HttpClient httpClient, ITdAmeritradeAuthService authService, IErrorHandler errorHandler) :
            base(
            authService, httpClient, errorHandler)
        { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="moverQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Mover[]> GetMovers(MoverQuery moverQuery, CancellationToken cancellationToken = default)
        {

            var uri = $"{baseUri}{moverQuery.IndexSymbol}/movers";

            var query = new Dictionary<string, string>
            {
                ["direction"] = moverQuery.Direction.ToString(),
                ["change"] = moverQuery.Change.ToString(),
            };

            uri = QueryHelpers.AddQueryString(uri, query);

            var movers = await GetAsync<Mover[]>(uri, cancellationToken);

            return movers;
        }
    }
}
