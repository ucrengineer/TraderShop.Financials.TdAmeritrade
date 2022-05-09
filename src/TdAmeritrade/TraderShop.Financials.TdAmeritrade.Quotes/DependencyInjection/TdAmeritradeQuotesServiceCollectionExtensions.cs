using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Quotes.Services;
using TraderShop.Financials.TdAmeritrade.Quotes.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Quotes.DependencyInjection
{
    public static class TdAmeritradeQuotesServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeQuotesProvider(this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeQuotesProvider, TdAmeritradeQuotesProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/marketdata/");
            });

            return services;
        }
    }
}
