using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Accounts.Services;
using TraderShop.Financials.TdAmeritrade.Accounts.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Accounts.DependencyInjection
{
    public static class TdAmeritradeAccountsServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeAccountProvider(
            this IServiceCollection services)
        {
            services.AddHttpClient<ITdAmeritradeAccountProvider, TdAmeritradeAccountProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/accounts/");
            });

            return services;
        }
    }
}
