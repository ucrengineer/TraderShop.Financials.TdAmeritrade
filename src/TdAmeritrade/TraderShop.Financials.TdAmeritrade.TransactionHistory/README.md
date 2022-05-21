# Transaction History Library

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
[TdAmeritrade API Documentation](https://developer.tdameritrade.com/transaction-history/apis "TdAmeritrade's API Documentation")

## Usage

```csharp
    public class TransactionHistoryProvider
    {
        private readonly ITdAmeritradeTransactionHistoryProvider _transactionHistoryProvider;
        private readonly TdAmeritradeOptions _options;

        public TransactionHistoryProvider(ItdAmeritradeTransactionHistoryProvider transactionHistoryProvider, TdAmeritradeOptions options)
        {
            _transactionHistoryProvider = transactionHistoryProvider;
            _options = options;
        }

        public async void BasicExample()
        {
            var result = await _transactionHistoryProvider.GetTransaction(_options.account_number, "42676990903");

            var result2 = await _transactionHistoryProvider.GetTransactions(_options.account_number, new TransactionQuery());

        }

    }
```

## Description

This library uses the TdAmeritrade API to retrieve transaction history. See the TransactionQuery object for more information.
