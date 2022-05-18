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
            /*
             * will have to create objects for order creation, it is a sensitive process.
             * possibly use premade json files for order placement
            */
            //var order = new
            //{
            //    orderType = "LIMIT",
            //    session = "NORMAL",
            //    price = "150",
            //    duration = "DAY",
            //    orderStrategyType = "SINGLE",
            //    orderLegCollection = new object[]
            //    {
            //        new
            //        {
            //            instruction = "BUY",
            //            quantity = 1,
            //            instrument = new
            //            {
            //                symbol = "MSFT",
            //                assetType = "EQUITY"
            //            }
            //        }
            //    }
            //};

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

        }

        [Fact]
        public async Task Replace_Order_Successfully()
        {
            /*
             * will have to create objects for order creation, it is a sensitive process.
             * possibly use premade json files for order placement
            */
            //var order = new
            //{
            //    orderType = "LIMIT",
            //    session = "NORMAL",
            //    price = "100",
            //    duration = "DAY",
            //    orderStrategyType = "SINGLE",
            //    orderLegCollection = new object[]
            //    {
            //        new
            //        {
            //            instruction = "BUY",
            //            quantity = 1,
            //            instrument = new
            //            {
            //                symbol = "MSFT",
            //                assetType = "EQUITY"
            //            }
            //        }
            //    }
            //};

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
        public async Task Cancel_Order_Successfully()
        {
            var orders = await _ordersProvider.GetOrdersByQuery();

            var order = orders.FirstOrDefault(x => x.Status != "CANCELED");

            var result = await _ordersProvider.CancelOrder(_options.account_number, order.OrderId.ToString());

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task Cancel_Order_Throws_Exception()
        {
            await Assert.ThrowsAsync<HttpRequestException>(async () => await _ordersProvider.CancelOrder(_options.account_number, "111"));
        }

        [Fact]
        public async Task Place_Order_Throws_Exception()
        {
            /*
             * will have to create objects for order creation, it is a sensitive process.
             * possibly use premade json files for order placement
            */
            //var order = new
            //{
            //    orderType = "LIMIT",
            //    session = "NORMAL",
            //    price = "150",
            //    duration = "DAY",
            //    orderStrategyType = "SINGLE",
            //    orderLegCollection = new object[]
            //    {
            //        new
            //        {
            //            instruction = "BUY",
            //            quantity = 1,
            //            instrument = new
            //            {
            //                symbol = "",
            //                assetType = "EQUITY"
            //            }
            //        }
            //    }
            //};

            var order = new PlaceOrder("LIMIT", 100,
       "NORMAL",
       "DAY",
       "SINGLE",
       new OrderLegCollection[]
       {
                    new OrderLegCollection("BUY",1,"MSFT","EQUITY")
       });

            await Assert.ThrowsAsync<HttpRequestException>(async () => await _ordersProvider.PlaceOrder(_options.account_number, order));

        }

        [Fact]
        public async Task Replace_Order_Throws_Exception()
        {
            /*
             * will have to create objects for order creation, it is a sensitive process.
             * possibly use premade json files for order placement
            */
            //var order = new
            //{
            //    orderType = "LIMIT",
            //    session = "NORMAL",
            //    price = "100",
            //    duration = "DAY",
            //    orderStrategyType = "SINGLE",
            //    orderLegCollection = new object[]
            //    {
            //        new
            //        {
            //            instruction = "BUY",
            //            quantity = 1,
            //            instrument = new
            //            {
            //                symbol = "MSFT",
            //                assetType = "EQUITY"
            //            }
            //        }
            //    }
            //};

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

        [Fact]
        public async Task Place_Conditional_Order_Successfully()
        {
            var order = new ConditionalTriggerOrder("LIMIT", 100,
                        "NORMAL",
                        "DAY",
                        "SINGLE",
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

            var result = await _ordersProvider.PlaceOrder<ConditionalTriggerOrder>(_options.account_number, order);


            Assert.Equal(0, result);

        }
    }
}
