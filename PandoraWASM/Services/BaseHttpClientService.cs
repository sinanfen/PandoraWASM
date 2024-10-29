using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PandoraWASM.Services;

public class BaseHttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public BaseHttpClientService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    // Token alma işlemini tek bir yerde yap
    protected async Task SetAuthorizationHeader(CancellationToken cancellationToken)
    {
        var token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken);
        if (!string.IsNullOrEmpty(token))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    protected async Task<T?> GetAsync<T>(string url, CancellationToken cancellationToken)
    {
        await SetAuthorizationHeader(cancellationToken);
        var response = await _httpClient.GetAsync(url, cancellationToken);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<T>(cancellationToken: cancellationToken);
        return default;
    }

    protected async Task<HttpResponseMessage> PostAsync<T>(string url, T data, CancellationToken cancellationToken)
    {
        await SetAuthorizationHeader(cancellationToken);
        return await _httpClient.PostAsJsonAsync(url, data, cancellationToken);
    }

    protected async Task<HttpResponseMessage> PutAsync<T>(string url, T data, CancellationToken cancellationToken)
    {
        await SetAuthorizationHeader(cancellationToken);
        return await _httpClient.PutAsJsonAsync(url, data, cancellationToken);
    }

    protected async Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken cancellationToken)
    {
        await SetAuthorizationHeader(cancellationToken);
        return await _httpClient.DeleteAsync(url, cancellationToken);
    }
}
