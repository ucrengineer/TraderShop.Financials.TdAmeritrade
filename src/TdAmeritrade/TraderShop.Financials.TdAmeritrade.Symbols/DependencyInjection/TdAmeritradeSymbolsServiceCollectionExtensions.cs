using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Symbols.Services;
using TraderShop.Financials.TdAmeritrade.Symbols.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Symbols.DependencyInjection
{
    public static class TdAmeritradeSymbolsServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeSymbolProvider(
            this IServiceCollection services)
        {
            services.AddHttpClient<ITdAmeritradeSymbolProvider, TdAmeritradeSymbolProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/instruments");
            });

            return services;
        }
    }
}
