using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TdAmeritrade.Financials.Functional.Tests.Utilities;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;
using TraderShop.Financials.TdAmeritrade.Orders.Models;
using TraderShop.Financials.TdAmeritrade.Orders.Services;
using Xunit;

namespace TdAmeritrade.Financials.Functional.Tests
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
            var result = await _ordersProvider.GetOrdersByPath(_options.account_number, orderQuery: new OrderQuery { FromEnteredTime = DateTime.Now.AddYears(-10) });

            Assert.NotNull(result);

            Assert.True(result.Length > 0);
        }

        [Fact]
        public async Task Return_Orders_By_Query_Successfully()
        {
            var result = await _ordersProvider.GetOrdersByQuery(orderQuery: new OrderQuery() { FromEnteredTime = DateTime.Now.AddYears(-1) });

            Assert.NotNull(result);

            Assert.NotNull(result.Select(x => x.OrderId == 5561127802));
        }

        [Fact]
        public async Task Place_Order_Successfully()
        {


            var order = new PlaceOrder("LIMIT", 100,
                "NORMAL",
                "DAY",
                "SINGLE",
                new OrderLegCollection[]
                {
                    new OrderLegCollection("BUY",1,"MSFT","EQUITY")
                });

            var result = await _ordersProvider.PlaceOrder(_options.account_number, order);

            Assert.Equal(0, result);

            var optionOrder = new OptionOrder(
                "NONE",
                "LIMIT",
                2.0,
                "NORMAL",
                "DAY",
                "SINGLE",
                new OrderLegCollection[]
                {
                    new OrderLegCollection(
                        "BUY_TO_OPEN",
                        1,
                        ".MSFT220715C245",
                        "OPTION")
                });

            var optionsResult = await _ordersProvider.PlaceOrder<OptionOrder>(_options.account_number, optionOrder);

            Assert.Equal(0, optionsResult);

            var verticalCallSpread = new OptionOrder(
                "VERTICAL",
                "NET_DEBIT",
                2.0,
                "NORMAL",
                "DAY",
                "SINGLE",
                new OrderLegCollection[]
                {
                    new OrderLegCollection(
                        "BUY_TO_OPEN",
                        1,
                        ".MSFT220715C245",
                        "OPTION"),
                    new OrderLegCollection(
                        "SELL_TO_OPEN",
                        1,
                        ".MSFT220617C250",
                        "OPTION"),
                });

            var optionsVerticalSpreadResult = await _ordersProvider.PlaceOrder<OptionOrder>(_options.account_number, verticalCallSpread);

            Assert.Equal(0, optionsVerticalSpreadResult);

            var conditionalOrder = new ConditionalTriggerOrder(
            "LIMIT",
            100,
            "NORMAL",
            "DAY",
            "TRIGGER",
            new OrderLegCollection[]
            {
                            new OrderLegCollection("BUY",1,"MSFT","EQUITY")
            },
            new PlaceOrder[]
            {
                            new PlaceOrder("LIMIT", 1,
                               "NORMAL",
                               "DAY",
                               "SINGLE",
                               new OrderLegCollection[]
                               {
                                            new OrderLegCollection("SELL",1,"MSFT","EQUITY")
                               })
            });

            var conditionalOrderResult = await _ordersProvider.PlaceOrder<ConditionalTriggerOrder>(_options.account_number, conditionalOrder);


            Assert.Equal(0, result);

        }

        [Fact]
        public async Task Replace_Order_Successfully()
        {

            var order = new PlaceOrder("LIMIT", 100,
                           "NORMAL",
                           "DAY",
                           "SINGLE",
                           new OrderLegCollection[]
                           {
                                        new OrderLegCollection("BUY",2,"MSFT","EQUITY")
                           });
            var result = await _ordersProvider.ReplaceOrder(_options.account_number, "5586319823", order);

            Assert.Equal(0, result);

        }

        [Fact]
        public async Task Cancel_Orders_Successfully()
        {
            var orders = await _ordersProvider.GetOrdersByQuery();

            foreach (var order in orders)
            {
                if (order.Status != "CANCELED")
                {
                    var result = await _ordersProvider.CancelOrder(_options.account_number, order.OrderId.ToString());
                    Assert.Equal(0, result);

                }

            }
        }

        [Fact]
        public async Task Cancel_Order_Throws_Exception()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () => await _ordersProvider.CancelOrder(_options.account_number, "111"));
        }

        [Fact]
        public async Task Place_Order_Throws_Exception()
        {

            var order = new PlaceOrder("LIMIT", 100,
                   "NORMAL",
                   "DAY",
                   "SINGLE",
                   new OrderLegCollection[]
                   {
                   });

            await Assert.ThrowsAsync<HttpRequestException>(async () => await _ordersProvider.PlaceOrder(_options.account_number, order));

        }

        [Fact]
        public async Task Replace_Order_Throws_Exception()
        {

            var order = new PlaceOrder("LIMIT", 100,
       "NORMAL",
       "DAY",
       "SINGLE",
       new OrderLegCollection[]
       {
                    new OrderLegCollection("BUY",1,"MSFT","EQUITY")
       });

            await Assert.ThrowsAsync<HttpRequestException>(async () => await _ordersProvider.ReplaceOrder(_options.account_number, "12345", order));
        }
    }
}
