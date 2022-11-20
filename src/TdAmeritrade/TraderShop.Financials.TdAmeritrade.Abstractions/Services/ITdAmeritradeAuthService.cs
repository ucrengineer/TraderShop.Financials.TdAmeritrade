namespace TraderShop.Financials.TdAmeritrade.Abstractions.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITdAmeritradeAuthService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetBearerToken(CancellationToken cancellationToken = default);
    }
}
