using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.MarketHours.Services;
using TraderShop.Financials.TdAmeritrade.MarketHours.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.MarketHours.DependencyInjection
{
    public static class TdAmeritradeMarketHoursServiceCollectionExtensions
    {
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
