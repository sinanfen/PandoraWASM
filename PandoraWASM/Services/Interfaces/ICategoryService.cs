using Pandora.Shared.DTOs.CategoryDTOs;

namespace PandoraWASM.Services.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> GetCategory(Guid categoryId, CancellationToken cancellationToken);
    Task<IList<CategoryDto>> GetCategories(CancellationToken cancellationToken);
}
