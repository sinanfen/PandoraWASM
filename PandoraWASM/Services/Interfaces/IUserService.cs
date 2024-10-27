using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Services.Interfaces;

public interface IUserService
{
    Task<UserDto> GetAsync(Guid userId, CancellationToken cancellationToken);
    Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> UpdateAsync(UserUpdateDto userUpdateDto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid userId, CancellationToken cancellationToken);
}