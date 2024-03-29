﻿using Microsoft.Extensions.DependencyInjection;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.OptionChains.Services;
using TraderShop.Financials.TdAmeritrade.OptionChains.Services.Impl;

namespace TraderShop.Financials.TdAmeritrade.OptionChains.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class TdAmeritradeOptionChainsServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTdAmeritradeOptionChainsProvider(
            this IServiceCollection services)
        {
            services.AddFinancialsAbstractionsServices();

            services.AddHttpClient<ITdAmeritradeOptionChainsProvider, TdAmeritradeOptionChainsProvider>(client =>
            {
                client.BaseAddress = new Uri("https://api.tdameritrade.com/v1/marketdata/chains");
            });

            return services;
        }
    }
}
