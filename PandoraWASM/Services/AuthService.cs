using System.Net.Http.Json;
using Blazored.LocalStorage;
using Pandora.Shared.DTOs.UserDTOs;
using PandoraWASM.Responses;
using PandoraWASM.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }

    public async Task<bool> LoginAsync(UserLoginDto loginDto, CancellationToken cancellationToken)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>(cancellationToken);

            if (loginResponse?.Token != null)
            {
                await _localStorage.SetItemAsync("authToken", loginResponse.Token, cancellationToken);
                return true;
            }
        }
        return false;
    }

    public async Task<bool> RegisterAsync(UserRegisterDto registerDto)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/register", registerDto);
        return response.IsSuccessStatusCode;
    }

    public async Task<string> ChangePasswordAsync(UserPasswordChangeDto changePasswordDto)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/change-password", changePasswordDto);
        if (response.IsSuccessStatusCode)
        {
            var successMessage = await response.Content.ReadAsStringAsync();
            return successMessage;
        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            return errorMessage;
        }
    }

    public async Task<string> GetTokenAsync()
    {
        try
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving token: {ex.Message}");
            return string.Empty;
        }
    }


    public async Task<UserDto> GetCurrentUserAsync()
    {
        var token = await GetTokenAsync();
        if (string.IsNullOrWhiteSpace(token))
        {
            return null;
        }

        var response = await _httpClient.GetAsync("auth/userinfo");
        if (response.IsSuccessStatusCode)
        {
            var userInfo = await response.Content.ReadFromJsonAsync<UserDto>();
            return userInfo;
        }

        return null;
    }
}
