using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.TransactionHistory.Models;

namespace TraderShop.Financials.TdAmeritrade.TransactionHistory.Services.Impl
{
    public class TdAmeritradeTransactionHistoryProvider : ITdAmeritradeTransactionHistoryProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IErrorHandler _errorHandler;
        private readonly ITdAmeritradeAuthService _authService;

        public TdAmeritradeTransactionHistoryProvider(HttpClient httpClient, IErrorHandler errorHandler, ITdAmeritradeAuthService authService)
        {
            _httpClient = httpClient;
            _errorHandler = errorHandler;
            _authService = authService;
        }


        public async Task<Transaction> GetTransaction(string accountId, string transactionId, CancellationToken cancellationToken = default)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId, transactionId });

            var uri = new Uri($"{_httpClient.BaseAddress}{accountId}/transactions/{transactionId}").ToString();

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

            var response = await _httpClient.GetAsync(uri, cancellationToken);

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var transaction = JsonConvert.DeserializeObject<Transaction>(responseObject);

            return transaction;
        }

        public async Task<Transaction[]> GetTransactions(string accountId, TransactionQuery transactionQuery, CancellationToken cancellationToken = default)
        {
            _errorHandler.CheckForNullOrEmpty(new string[] { accountId });

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

            await _errorHandler.CheckForErrorsAsync(response);

            var responseObject = await response.Content.ReadAsStringAsync();

            var transactions = JsonConvert.DeserializeObject<Transaction[]>(responseObject);

            return transactions;

        }
    }
}
