using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Services;

public interface IAuthService
{
    Task<bool> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken);
    Task<bool> RegisterAsync(UserRegisterDto registerDto);
    Task<string> ChangePasswordAsync(UserPasswordChangeDto changePasswordDto);
    Task<string> GetTokenAsync();
    Task<UserDto> GetCurrentUserAsync();
}
