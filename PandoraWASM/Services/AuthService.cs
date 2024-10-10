using System.Net.Http.Headers;
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

    public async Task<bool> LoginAsync(UserLoginDto loginDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto);

        if (response.IsSuccessStatusCode)
        {
            var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.Token))
            {
                await _localStorage.SetItemAsync("authToken", loginResponse.Token);
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
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

    public async Task<bool> ChangePasswordAsync(UserPasswordChangeDto changePasswordDto)
    {
        var response = await _httpClient.PostAsJsonAsync("auth/change-password", changePasswordDto);
        return response.IsSuccessStatusCode;
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("authToken");
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<string> GetTokenAsync()
    {
        return await _localStorage.GetItemAsync<string>("authToken");
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
