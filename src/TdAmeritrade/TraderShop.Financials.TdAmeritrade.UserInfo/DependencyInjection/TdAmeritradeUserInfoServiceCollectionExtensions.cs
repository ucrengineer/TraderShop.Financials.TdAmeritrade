using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.UserInfo.Services;
using TraderShop.Financials.TdAmeritrade.UserInfo.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.UserInfo.DependencyInjection
{
    public static class TdAmeritradeUserInfoServiceCollectionExtensions
    {
        public static IServiceCollection AddTdAmeritradeUserInfoProvider(this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeUserInfoProvider, TdAmeritradeUserInfoProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/accounts/");
            });

            return services;
        }
    }
}
