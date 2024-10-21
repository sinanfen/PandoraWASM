using Blazored.LocalStorage;
using Pandora.Shared.DTOs.CategoryDTOs;
using PandoraWASM.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PandoraWASM.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public CategoryService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public async Task<IList<CategoryDto>> GetCategories(CancellationToken cancellationToken)
    {
        try
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken); // Fetch token from local storage
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/categories", cancellationToken);
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<List<CategoryDto>>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<CategoryDto> GetCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        try
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken); // Fetch token from local storage
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/categories/{categoryId}", cancellationToken);
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<CategoryDto>();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
