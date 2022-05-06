using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Orders.Models;
using TraderShop.Financials.TdAmeritrade.Orders.Services;
using Xunit;

namespace TdAmeritrade.Financials.Tests
{
    public class OrdersProvider
    {
        private readonly ITdAmeritradeOrdersProvider _ordersProvider;
        private readonly TdAmeritradeOptions _options;

        public OrdersProvider()
        {
            _ordersProvider = TestHelper.GetServiceProvider().GetRequiredService<ITdAmeritradeOrdersProvider>();
            _options = TestHelper.GetServiceProvider().GetRequiredService<IOptionsMonitor<TdAmeritradeOptions>>().CurrentValue;
        }

        [Fact]
        public async Task Return_Order_Successfully()
        {
            var result = await _ordersProvider.GetOrder(_options.account_number, "5408819438");

            Assert.NotNull(result);
            Assert.Equal(_options.account_number, result.AccountId.ToString());
        }

        [Fact]
        public async Task Return_Orders_By_Path_Successfully()
        {
            var result = await _ordersProvider.GetOrdersByPath(_options.account_number, new OrderQuery { FromEnteredTime = DateTime.Now.AddYears(-10) });

            var orderAPT = result.FirstOrDefault(x => x.OrderId == 5198538993);

            Assert.NotNull(result);

            Assert.True(result.Length > 0);
        }

        [Fact]
        public async Task Return_Orders_By_Query_Successfully()
        {
            var result = await _ordersProvider.GetOrdersByQuery();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Place_Orders_Successfully()
        {
            /*
             * will have to create objects for order creation, it is a sensitive process.
             * possibly use premade json files for order placement
            */
            var order = new
            {
                orderType = "LIMIT",
                session = "NORMAL",
                price = "150",
                duration = "DAY",
                orderStrategyType = "SINGLE",
                orderLegCollection = new object[]
                {
                    new
                    {
                        instruction = "BUY",
                        quantity = 1,
                        instrument = new
                        {
                            symbol = "",
                            assetType = "EQUITY"
                        }
                    }
                }
            };

            var exception = await Assert.ThrowsAsync<Exception>(async () => await _ordersProvider.PlaceOrder(_options.account_number, order));

            var message = "{\n  \"error\" : \"Please enter a valid symbol.\"\n}";

            Assert.Equal(message, exception.Message);

        }
    }
}
