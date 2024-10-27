using Pandora.Shared.DTOs.CategoryDTOs;

namespace PandoraWASM.Services.Interfaces;

public interface ICategoryService
{
    Task<IList<CategoryDto>?> GetCategories(CancellationToken cancellationToken);
    Task<CategoryDto?> GetCategory(Guid categoryId, CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> AddCategory(CategoryAddDto categoryDto, CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> UpdateCategory(Guid categoryId, CategoryUpdateDto categoryDto, CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> DeleteCategory(Guid categoryId, CancellationToken cancellationToken);
}
