using TraderShop.Financials.TdAmeritrade.OptionChains.Models;

namespace TraderShop.Financials.TdAmeritrade.OptionChains.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITdAmeritradeOptionChainsProvider
    {
        /// <summary>
        /// Get option chain for an optionable Symbol
        /// </summary>
        /// <param name="optionQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<OptionChain> GetOptionChain(OptionChainQuery optionQuery, CancellationToken cancellationToken = default);
    }
}
