using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection
{
    /// <summary>
    /// Adds all services needed for tdameritrade library
    /// </summary>
    public static class TdAmeritradeServiceCollectionExtensions
    {
        /// <summary>
        /// DI for adding TdAmeritrade Auth Service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTdAmeritradeClient(
            this IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeAuthService, TdAmeritradeAuthService>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/oauth2/token");
            });

            return services;
        }
    }
}
