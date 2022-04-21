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
            //services.TryAddScoped<ITdAmeritradeClientService, TdAmeritradeClientService>();
            services.AddHttpClient<ITdAmeritradeClientService, TdAmeritradeClientService>(client =>
            {
                // set up options pattern
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/");
            });
            return services;
        }
    }
}
