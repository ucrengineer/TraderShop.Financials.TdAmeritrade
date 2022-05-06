using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Orders.Services;
using TraderShop.Financials.TdAmeritrade.Orders.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Orders.DependencyInjection
{
    public static class TdAmeritradeOrdersServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeOrdersProvider(
        this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeOrdersProvider, TdAmeritradeOrdersProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/accounts/");
            });

            return services;
        }
    }
}
