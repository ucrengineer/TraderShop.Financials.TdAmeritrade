using TraderShop.Financials.TdAmeritrade.TransactionHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.Services
{
    public interface ITdAmeritradeTransactionHistoryProvider
    {
        /// <summary>
        /// Transaction for a specific account.
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transactionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Transaction> GetTransaction(string accountId, string transactionId, CancellationToken cancellationToken = default);
        /// <summary>
        /// Transactions for a specific account.
        /// </summary>
        /// <param name="accoundId"></param>
        /// <param name="transactionQuery"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Transaction[]> GetTransactions(string accountId, TransactionQuery transactionQuery, CancellationToken cancellationToken = default);
    }
}
