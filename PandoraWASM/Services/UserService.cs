using System.Net.Http.Headers;
using System.Net.Http.Json;
using Blazored.LocalStorage;
using Pandora.Shared.DTOs.UserDTOs;
using PandoraWASM.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public UserService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public async Task<UserDto> GetUserAsync(Guid userId)
    {
        var token = await _localStorageService.GetItemAsync<string>("authToken"); // Fetch token from local storage

        if (!string.IsNullOrEmpty(token))
        {
            // Attach token to Authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        var response = await _httpClient.GetAsync($"api/users/{userId}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<UserDto>();
        }

        return null;
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var response = await _httpClient.GetAsync("api/users");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<UserDto>>();
        }
        return new List<UserDto>();
    }

    public async Task<(bool Success, string? ErrorMessage)> UpdateIndividualUserAsync(IndividualUserUpdateDto individualUserUpdateDto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/users/individual/{individualUserUpdateDto.Id}", individualUserUpdateDto);

            if (response.IsSuccessStatusCode)
                return (true, null);
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return (false, $"Error: {response.StatusCode}. Details: {content}");
            }
        }
        catch (Exception ex)
        {
            return (false, $"Exception: {ex.Message}");
        }
    }

    public async Task<(bool Success, string? ErrorMessage)> UpdateCorporateUserAsync(CorporateUserUpdateDto corporateUserUpdateDto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/users/corporate/{corporateUserUpdateDto.Id}", corporateUserUpdateDto);

            if (response.IsSuccessStatusCode)
                return (true, null);
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                return (false, $"Error: {response.StatusCode}. Details: {content}");
            }
        }
        catch (Exception ex)
        {
            return (false, $"Exception: {ex.Message}");
        }
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        var response = await _httpClient.DeleteAsync($"api/users/delete/{userId}");
        return response.IsSuccessStatusCode;
    }
}