using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.TransactionHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.Services.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class TdAmeritradeTransactionHistoryProvider : ITdAmeritradeTransactionHistoryProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IErrorHandler _errorHandler;
        private readonly ITdAmeritradeAuthService _authService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="errorHandler"></param>
        /// <param name="authService"></param>
        public TdAmeritradeTransactionHistoryProvider(HttpClient httpClient, IErrorHandler errorHandler, ITdAmeritradeAuthService authService)
        {

            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
           


            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));

            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="transactionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Transaction> GetTransaction(string accountId, string transactionId, CancellationToken cancellationToken = default)
        {
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/transactions/{transactionId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var transaction = JsonConvert.DeserializeObject<Transaction>(responseObject);

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
            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/transactions").ToString();


            var query = new Dictionary<string, string>
            {
                ["type"] = transactionQuery.Type.ToString(),
                ["symbol"] = transactionQuery.Symbol,
                ["startDate"] = transactionQuery.StartDate.ToString("yyyy-MM-dd"),
                ["endDate"] = transactionQuery.EndDate.ToString("yyyy-MM-dd")
            };

            uri = QueryHelpers.AddQueryString(uri, query);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckQueryErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var transactions = JsonConvert.DeserializeObject<Transaction[]>(responseObject);

            return transactions;

        }
    }
}
