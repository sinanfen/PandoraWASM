using System.Net.Http.Json;
using Blazored.LocalStorage;
using Pandora.Shared.DTOs.UserDTOs;
using PandoraWASM.Responses;
using PandoraWASM.Services;
using PandoraWASM.Services.Interfaces;

public class AuthService : BaseHttpClientService, IAuthService
{
    private readonly ILocalStorageService _localStorageService;

    public AuthService(HttpClient httpClient, ILocalStorageService localStorageService)
        : base(httpClient, localStorageService)
    {
        _localStorageService = localStorageService;
    }

    public async Task<(bool isSuccess, string message, string token)> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken)
    {
        var response = await PostAsync("api/auth/login", loginDto, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken);
            if (loginResponse != null && loginResponse.Success && !string.IsNullOrEmpty(loginResponse.Token))
            {
                await _localStorageService.SetItemAsync("authToken", loginResponse.Token, cancellationToken);
                return (true, loginResponse.Message ?? "Login successful!", loginResponse.Token);
            }
            return (false, loginResponse?.Message ?? "Login failed.", null);
        }
        return (false, $"Login request failed with status: {response.StatusCode}", null);
    }


    public async Task<(bool isSuccess, string message)> RegisterAsync(UserRegisterDto registerDto, CancellationToken cancellationToken)
    {
        var response = await PostAsync("api/auth/register", registerDto, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var registerResponse = await response.Content.ReadFromJsonAsync<RegisterResponse>(cancellationToken);
            return (registerResponse?.Success ?? false, registerResponse?.Message ?? "Registration successful!");
        }
        return (false, $"Registration request failed with status: {response.StatusCode}");
    }

    public async Task<string> ChangePasswordAsync(UserPasswordChangeDto changePasswordDto)
    {
        var response = await PostAsync("auth/change-password", changePasswordDto, CancellationToken.None);
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<UserDto> GetCurrentUserAsync()
    {
        var cts = new CancellationTokenSource();
        await SetAuthorizationHeader(cts.Token);
        return await GetAsync<UserDto>("/api/users/userinfo", CancellationToken.None);
    }
}
