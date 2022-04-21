using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection
{
    public static class TdAmeritradeServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeClient(
            this IServiceCollection services)
        {
            services.TryAddScoped<ITdAmeritradeClientService, TdAmeritradeClientService>();
            return services;
        }
    }
}
