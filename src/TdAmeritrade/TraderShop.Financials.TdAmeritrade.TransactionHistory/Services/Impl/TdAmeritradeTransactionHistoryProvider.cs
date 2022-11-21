using Microsoft.AspNetCore.WebUtilities;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.TransactionHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.Services.Impl
{
    /// <summary>
    ///
    /// </summary>
    public class TdAmeritradeTransactionHistoryProvider : BaseTdAmeritradeProvider, ITdAmeritradeTransactionHistoryProvider
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        /// <param name="authService"></param>
        public TdAmeritradeTransactionHistoryProvider(HttpClient httpClient,
                                                      IErrorHandler errorHandler,
                                                      ITdAmeritradeAuthService authService)
        : base(
            authService, httpClient, errorHandler)
        { }
        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transactionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransaction(string accountId, string transactionId, CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}{accountId}/transactions/{transactionId}";

            var transaction = await GetAsync<Transaction>(uri, cancellationToken);

            return transaction;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transactionQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Transaction[]> GetTransactions(string accountId, TransactionQuery transactionQuery, CancellationToken cancellationToken = default)
        {
            var uri = $"{baseUri}{accountId}/transactions";

            var query = new Dictionary<string, string>
            {
                ["type"] = transactionQuery.Type.ToString(),
                ["symbol"] = transactionQuery.Symbol,
                ["startDate"] = transactionQuery.StartDate.ToString("yyyy-MM-dd"),
                ["endDate"] = transactionQuery.EndDate.ToString("yyyy-MM-dd")
            };

            uri = QueryHelpers.AddQueryString(uri, query);

            var transactions = await GetAsync<Transaction[]>(uri, cancellationToken);

            return transactions;

        }
    }
}
