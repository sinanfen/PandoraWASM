using System.Net.Http.Json;
using Pandora.Shared.DTOs.UserDTOs;
using PandoraWASM.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDto> GetUserAsync(Guid userId)
    {
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

    public async Task<bool> UpdateUserAsync(UserUpdateDto userUpdateDto)
    {
        var response = await _httpClient.PutAsJsonAsync("api/users/update", userUpdateDto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        var response = await _httpClient.DeleteAsync($"api/users/delete/{userId}");
        return response.IsSuccessStatusCode;
    }
}