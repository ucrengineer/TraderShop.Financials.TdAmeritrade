# Orders Library

<img src="https://img.shields.io/github/issues/ucrengineer/TraderShop.Financials"
    alt = "home screen"
    style = "float: left"/>
<img src="https://img.shields.io/github/forks/ucrengineer/TraderShop.Financials"
    alt = "home screen"
    style = "float: left"/>
<img src="https://img.shields.io/github/stars/ucrengineer/TraderShop.Financials"
    alt = "home screen"
    style = "float: left"/>
<img src="https://img.shields.io/github/license/ucrengineer/TraderShop.Financials.TdAmeritrade"
    alt = "home screen"
    style = "float: left"/>

<br></br>

[TdAmeritrade API Documentation](https://developer.tdameritrade.com/account-access/apis "TdAmeritrade's API Documentation")

## Usage

```csharp
  public class OrdersProvider
    {
        private readonly ITdAmeritradeOrdersProvider _ordersProvider;
        private readonly TdAmeritradeOptions _options;

        public OrdersProvider(ITdAmeritradeOrdersProvider ordersProvider, TdAmeritradeOptions options)
        {
            _ordersProvider = ordersProvider;
            _options = options;
        }

        public async Task Return_Order_Successfully()
        {
            var result = await _ordersProvider.GetOrder(_options.account_number, "5408819438");
        }

        public async Task Return_Orders_By_Path_Successfully()
        {
            var result = await _ordersProvider.GetOrdersByPath(_options.account_number, orderQuery: new OrderQuery { FromEnteredTime = DateTime.Now.AddYears(-10) });
        }

        public async Task Return_Orders_By_Query_Successfully()
        {
            var result = await _ordersProvider.GetOrdersByQuery(orderQuery: new OrderQuery() { FromEnteredTime = DateTime.Now.AddYears(-1) });
        }

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
        }

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

        }

        public async Task Cancel_Order_Successfully()
        {
            var orders = await _ordersProvider.GetOrdersByQuery();

            var order = orders.FirstOrDefault(x => x.Status != "CANCELED");

            var result = await _ordersProvider.CancelOrder(_options.account_number, order.OrderId.ToString());

        }

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


        }
    }
```

## Desciption

This library is in charge of interacting with the TdAmeritrade API to retrieve & place orders.
