using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
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
    /// <param name="uri"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> DeleteAsync(string uri, CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

        var response = await _httpClient.DeleteAsync(uri, cancellationToken);

        await _errorHandler.CheckCommandErrorsAsync(response);

        return 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="uri"></param>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> PostAsync<T>(string uri, T model, CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

        var preferencesJson = JsonConvert.SerializeObject(model);

        var content = new StringContent(preferencesJson, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(uri, content, cancellationToken);

        await _errorHandler.CheckCommandErrorsAsync(response);

        return 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="uri"></param>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> PatchAsync<T>(string uri, T model, CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

        var preferencesJson = JsonConvert.SerializeObject(model);

        var content = new StringContent(preferencesJson, Encoding.UTF8, "application/json");

        var response = await _httpClient.PatchAsync(uri, content, cancellationToken);

        await _errorHandler.CheckCommandErrorsAsync(response);

        return 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="uri"></param>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> PutAsync<T>(string uri, T model, CancellationToken cancellationToken)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

        var preferencesJson = JsonConvert.SerializeObject(model);

        var content = new StringContent(preferencesJson, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(uri, content, cancellationToken);

        await _errorHandler.CheckCommandErrorsAsync(response);

        return 0;

    }
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="uri"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken)
    {

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _authService.GetBearerToken());

        var response = await _httpClient.GetAsync(uri, cancellationToken);

        await _errorHandler.CheckQueryErrorsAsync(response);

        var responseObject = await response.Content.ReadAsStringAsync();

        var result = Deserialize<T>(responseObject);

        return result;
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    public T Deserialize<T>(string? json)
    {
        if (string.IsNullOrEmpty(json))
            throw new ArgumentNullException("Cannot deserialized a empty or null string");

        var result = JsonConvert.DeserializeObject<T>(json);

        if (result is null)
            throw new ArgumentNullException(nameof(T));

        return result;
    }
}