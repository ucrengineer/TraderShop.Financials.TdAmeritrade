using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Instruments.Services;
using TraderShop.Financials.TdAmeritrade.Instruments.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Symbols.DependencyInjection
{
    public static class TdAmeritradeSymbolsServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeInstrumentProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeInstrumentProvider, TdAmeritradeInstrumentProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/instruments");
            });

            return services;
        }
    }
}
