using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Services;

public interface IUserService
{
    Task<UserDto> GetUserAsync(Guid userId,CancellationToken cancellationToken);
    Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> UpdateUserAsync(UserUpdateDto userUpdateDto, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(Guid userId,CancellationToken cancellationToken);
}