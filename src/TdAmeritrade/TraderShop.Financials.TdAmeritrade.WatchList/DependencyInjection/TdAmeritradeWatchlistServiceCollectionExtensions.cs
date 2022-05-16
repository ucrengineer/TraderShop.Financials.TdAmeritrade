using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Watchlist.Services;
using TraderShop.Financials.TdAmeritrade.Watchlist.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Watchlist.DependencyInjection
{
    public static class TdAmeritradeWatchlistServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeWatchlistProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeWatchlistProvider, TdAmeritradeWatchlistProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/accounts/");
            });

            return services;
        }
    }
}
