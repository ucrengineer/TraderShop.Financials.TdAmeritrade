using Microsoft.Extensions.DependencyInjection;
using TraderShop.Finacials.TdAmeritrade.PriceHistory.Services;
using TraderShop.Finacials.TdAmeritrade.PriceHistory.Services.Impl;

namespace TraderShop.Finacials.TdAmeritrade.PriceHistory.DependencyInjection
{
    public static class TdAmeritradePriceHistoryServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradePriceHistoryProvider(
            this IServiceCollection services)
        {
            services.AddHttpClient<ITdAmeriradePriceHistoryProvider, TdAmeritradePriceHistoryProvider>(client =>
          {
              client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/marketdata/");
          });

            return services;
        }
    }
}
