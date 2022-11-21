using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.SavedOrders.Services;
using TraderShop.Financials.TdAmeritrade.SavedOrders.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.SavedOrders.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class TdAmeritradeSavedOrdersServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTdAmeritradeSavedOrdersProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeSavedOrdersProvider, TdAmeritradeSavedOrdersProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/accounts/");
            });

            return services;
        }
    }
}
