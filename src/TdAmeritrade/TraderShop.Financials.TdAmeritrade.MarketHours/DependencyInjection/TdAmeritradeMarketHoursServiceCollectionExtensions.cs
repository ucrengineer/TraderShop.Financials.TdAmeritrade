using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.MarketHours.Services;
using TraderShop.Financials.TdAmeritrade.MarketHours.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.MarketHours.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class TdAmeritradeMarketHoursServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTdAmeritradeMarketHoursProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeMarketHoursProvider, TdAmeritradeMarketHoursProvider>(client =>
             {
                 client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/marketdata/hours");
             });

            return services;
        }
    }


}
