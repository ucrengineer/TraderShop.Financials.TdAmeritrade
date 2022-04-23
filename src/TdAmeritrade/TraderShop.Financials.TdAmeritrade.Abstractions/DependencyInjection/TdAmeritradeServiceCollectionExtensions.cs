using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection
{
    public static class TdAmeritradeServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeClient(
            this IServiceCollection services)
        {
            services.AddHttpClient<ITdAmeritradeClientService, TdAmeritradeClientService>();

            return services;
        }
    }
}
