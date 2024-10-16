using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Services;

public interface IAuthService
{
    Task<(bool isSuccess, string message)> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken);
    Task<(bool isSuccess, string message)> RegisterAsync(UserRegisterDto registerDto, CancellationToken cancellationToken);
    Task<string> ChangePasswordAsync(UserPasswordChangeDto changePasswordDto);
    Task<string> GetTokenAsync();
    Task<UserDto> GetCurrentUserAsync();
}
