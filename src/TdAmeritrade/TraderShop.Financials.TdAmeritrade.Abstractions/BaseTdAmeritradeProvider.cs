using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraderShop.Financials.Abstractions.Services;
using TraderShop.Financials.TdAmeritrade.Abstractions.Services;

namespace TraderShop.Financials.TdAmeritrade.Abstractions;

/// <summary>
///
/// </summary>
public class BaseTdAmeritradeProvider
{
    private readonly ITdAmeritradeAuthService _authService;
    private readonly HttpClient _httpClient;
    private readonly IErrorHandler _errorHandler;
    /// <summary>
    ///
    /// </summary>
    /// <param name="authService"></param>
    /// <param name="httpClient"></param>
    /// <param name="errorHandler"></param>
    /// <param name="deserializerService"></param>
    public BaseTdAmeritradeProvider(
            ITdAmeritradeAuthService authService,
            HttpClient httpClient,
            IErrorHandler errorHandler)
    {
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));

        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
    }

    /// <summary>
    ///
    /// </summary>
    public string baseUri => new Uri($"{_httpClient.BaseAddress}").ToString();

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="uri"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken) where T : class
    {

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

        var response = await _httpClient.GetAsync(uri, cancellationToken);

        await _errorHandler.CheckQueryErrorsAsync(response);

        var responseObject = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<T>(responseObject);

        if (result is null)
            throw new ArgumentNullException(nameof(T));

        return result;
    }
}