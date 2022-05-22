using Microsoft.Extensions.DependencyInjection;
using TraderShop.Finacials.TdAmeritrade.PriceHistory.Services;
using TraderShop.Finacials.TdAmeritrade.PriceHistory.Services.Impl;
using TraderShop.Financials.Abstractions.DependencyInjection;

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
