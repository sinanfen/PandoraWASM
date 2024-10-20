using Pandora.Shared.DTOs.CategoryDTOs;

namespace PandoraWASM.Services;

public interface ICategoryService
{
    Task<CategoryDto> GetCategory(Guid categoryId, Guid userId, CancellationToken cancellationToken);
    Task<IList<CategoryDto>> GetCategories(Guid userId, CancellationToken cancellationToken);
}
