using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Services;

public interface IUserService
{
    Task<UserDto> GetUserAsync(Guid userId);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<bool> UpdateUserAsync(UserUpdateDto userUpdateDto);
    Task<bool> DeleteUserAsync(Guid userId);
}