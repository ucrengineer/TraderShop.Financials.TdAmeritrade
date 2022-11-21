using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.TransactionHistory.Services;
using TraderShop.Financials.TdAmeritrade.TransactionHistory.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class TdAmeritradeTransactionHistoryServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTdAmeritradeTransactionHistoryProvider(this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeTransactionHistoryProvider, TdAmeritradeTransactionHistoryProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/accounts/");
            });

            return services;
        }
    }
}
