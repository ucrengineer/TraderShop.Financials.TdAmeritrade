using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Services;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.PriceHistory.DependencyInjection
{
    public static class TdAmeritradePriceHistoryServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradePriceHistoryProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradePriceHistoryProvider, TdAmeritradePriceHistoryProvider>(client =>
          {
              client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/marketdata/");
          });

            return services;
        }
    }
}
