using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.WatchList.Services;
using TraderShop.Financials.TdAmeritrade.WatchList.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.WatchList.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class TdAmeritradeWatchlistServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTdAmeritradeWatchlistProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeWatchlistProvider, TdAmeritradeWatchlistProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/accounts/");
            });

            return services;
        }
    }
}
