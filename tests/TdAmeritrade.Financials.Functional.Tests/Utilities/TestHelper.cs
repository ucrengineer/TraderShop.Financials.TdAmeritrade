using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TraderShop.Financials.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Accounts.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.MarketHours.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Movers.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.OptionChains.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Orders.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.PriceHistory.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Quotes.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.SavedOrders.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Symbols.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.TransactionHistory.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.UserInfo.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.WatchList.DependencyInjection;

namespace TdAmeritrade.Financials.Functional.Tests.Utilities
{
    public static class TestHelper
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();


            var options = JsonConvert.DeserializeObject<Dictionary<string, TdAmeritradeOptions>>
                (File.ReadAllText(@"C:\Users\ucren\source\repos\TraderShop.Financials.TdAmeritrade\src\TdAmeritrade\TraderShop.Financials.TdAmeritrade.Console\appsettings.Development.json"));

            services.Configure<TdAmeritradeOptions>(x =>
            {
                x.auth_url = options[nameof(TdAmeritradeOptions)].auth_url;
                x.account_number = options[nameof(TdAmeritradeOptions)].account_number;
                x.client_id = options[nameof(TdAmeritradeOptions)].client_id;
                x.refresh_token = options[nameof(TdAmeritradeOptions)].refresh_token;
            });

            services.AddFinancialsAbstractionsServices();

            services.AddTdAmeritradeClient();

            services.AddTdAmeritradeInstrumentProvider();

            services.AddTdAmeritradePriceHistoryProvider();

            services.AddTdAmeritradeAccountProvider();

            services.AddTdAmeritradeSavedOrdersProvider();

            services.AddTdAmeritradeOrdersProvider();

            services.AddTdAmeritradeQuotesProvider();

            services.AddTdAmeritradeMoverProvider();

            services.AddTdAmeritradeMarketHoursProvider();

            services.AddTdAmeritradeTransactionHistoryProvider();

            services.AddTdAmeritradeUserInfoProvider();

            services.AddTdAmeritradeOptionChainsProvider();

            services.AddTdAmeritradeWatchlistProvider();

            return services.BuildServiceProvider();
        }
    }
}
