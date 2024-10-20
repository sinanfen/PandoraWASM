using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Services;

public interface IUserService
{
    Task<UserDto> GetUserAsync(Guid userId);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<(bool Success, string? ErrorMessage)> UpdateUserAsync(UserUpdateDto userUpdateDto, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(Guid userId);
}