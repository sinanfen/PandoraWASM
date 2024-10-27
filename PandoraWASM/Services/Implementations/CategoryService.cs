using Blazored.LocalStorage;
using Pandora.Shared.DTOs.CategoryDTOs;
using PandoraWASM.Services.Interfaces;

namespace PandoraWASM.Services.Implementations;

public class CategoryService : BaseHttpClientService, ICategoryService
{
    public CategoryService(HttpClient httpClient, ILocalStorageService localStorageService)
        : base(httpClient, localStorageService)
    {
    }

    public async Task<IList<CategoryDto>?> GetCategories(CancellationToken cancellationToken)
    {
        return await GetAsync<List<CategoryDto>>("api/categories", cancellationToken);
    }

    public async Task<CategoryDto?> GetCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        return await GetAsync<CategoryDto>($"api/categories/{categoryId}", cancellationToken);
    }

    public async Task<(bool Success, string? ErrorMessage)> AddCategory(CategoryAddDto categoryDto, CancellationToken cancellationToken)
    {
        var response = await PostAsync("api/categories", categoryDto, cancellationToken);
        return await ProcessHttpResponse(response);
    }

    public async Task<(bool Success, string? ErrorMessage)> UpdateCategory(Guid categoryId, CategoryUpdateDto categoryDto, CancellationToken cancellationToken)
    {
        var response = await PutAsync($"api/categories/{categoryId}", categoryDto, cancellationToken);
        return await ProcessHttpResponse(response);
    }

    public async Task<(bool Success, string? ErrorMessage)> DeleteCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        var response = await DeleteAsync($"api/categories/{categoryId}", cancellationToken);
        return await ProcessHttpResponse(response);
    }

    private async Task<(bool Success, string? ErrorMessage)> ProcessHttpResponse(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            return (true, null);
        }

        // Hata durumunda ayrıntılı hata mesajını döndür
        var errorMessage = await response.Content.ReadAsStringAsync();
        return (false, errorMessage);
    }
}
