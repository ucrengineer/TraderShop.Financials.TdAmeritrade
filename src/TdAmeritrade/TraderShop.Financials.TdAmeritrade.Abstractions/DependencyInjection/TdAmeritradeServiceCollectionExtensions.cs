using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection
{
    public static class TdAmeritradeServiceCollectionExtensions
    {
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
