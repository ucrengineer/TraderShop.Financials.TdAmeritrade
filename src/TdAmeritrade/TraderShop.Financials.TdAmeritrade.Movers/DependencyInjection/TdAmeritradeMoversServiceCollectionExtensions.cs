using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Movers.Services;
using TraderShop.Financials.TdAmeritrade.Movers.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Movers.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class TdAmeritradeMoversServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTdAmeritradeMoverProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeMoverProvider, TdAmeritradeMoverProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/marketdata/");
            });

            return services;
        }
    }
}
