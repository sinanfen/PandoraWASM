using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Services.Interfaces;

public interface IAuthService
{
    Task<(bool isSuccess, string message, string token)> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken);
    Task<(bool isSuccess, string message)> RegisterAsync(UserRegisterDto registerDto, CancellationToken cancellationToken);
    Task<string> ChangePasswordAsync(UserPasswordChangeDto changePasswordDto);
    Task<UserDto?> GetCurrentUserAsync();
}
