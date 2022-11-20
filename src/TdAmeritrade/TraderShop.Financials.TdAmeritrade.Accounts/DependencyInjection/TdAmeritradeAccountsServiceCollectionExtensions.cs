using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Accounts.Services;
using TraderShop.Financials.TdAmeritrade.Accounts.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.Accounts.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class TdAmeritradeAccountsServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTdAmeritradeAccountProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeAccountProvider, TdAmeritradeAccountProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/accounts/");
            });

            return services;
        }
    }
}
