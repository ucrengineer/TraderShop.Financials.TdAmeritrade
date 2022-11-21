using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.OptionChains.Models;

namespace TraderShop.Financials.TdAmeritrade.OptionChains.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeOptionChainsProvider : BaseTdAmeritradeProvider, ITdAmeritradeOptionChainsProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        /// <param name="authService"></param>
        public TdAmeritradeOptionChainsProvider(
            HttpClient httpClient,
            IErrorHandler errorHandler,
            ITdAmeritradeAuthService authService)
            : base(authService, httpClient, errorHandler) { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="optionQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<OptionChain> GetOptionChain(OptionChainQuery optionQuery, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, string>
            {
                ["symbol"] = optionQuery.Symbol,
                ["contractType"] = optionQuery.ContractType.ToString(),
                ["includeQuotes"] = optionQuery.IncludeQuotes.ToString(),
                ["strategy"] = optionQuery.Strategy.ToString(),
                ["interval"] = optionQuery.Interval.ToString(),
                ["strike"] = optionQuery.Strike.ToString() ?? string.Empty,
                ["strikeCount"] = optionQuery.StrikeCount.ToString() ?? string.Empty,
                ["range"] = optionQuery.Range.ToString(),
                ["fromDate"] = optionQuery.FromDate.ToString("yyyy-MM-dd"),
                ["toDate"] = optionQuery.ToDate.ToString("yyyy-MM-dd"),
                ["volatility"] = optionQuery.Volatility.ToString(),
                ["underlyingPrice"] = optionQuery.UnderlyingPrice.ToString(),
                ["interestRate"] = optionQuery.InterestRate.ToString(),
                ["daysToExpiration"] = optionQuery.DaysToExpiration.ToString(),
                ["expMonth"] = optionQuery.ExpMonth.ToString(),
                ["optionType"] = optionQuery.OptionType.ToString()
            };

            var uri = QueryHelpers.AddQueryString(baseUri, query);

            var optionChain = await GetAsync<OptionChain>(uri, cancellationToken);

            return optionChain;
        }
    }
}
