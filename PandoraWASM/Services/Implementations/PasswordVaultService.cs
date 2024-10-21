using Blazored.LocalStorage;
using Pandora.Shared.DTOs.PasswordVaultDTOs;
using Pandora.Shared.DTOs.PersonalVaultDTOs;
using PandoraWASM.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PandoraWASM.Services.Implementations;

public class PasswordVaultService : IPasswordVaultService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public PasswordVaultService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public async Task<PasswordVaultDto> GetPasswordVault(Guid passwordVaultId, CancellationToken cancellationToken)
    {
        try
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken); // Fetch token from local storage
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/passwordVaults/{passwordVaultId}", cancellationToken);
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<PasswordVaultDto>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IList<PasswordVaultDto>> GetPasswordVaults(CancellationToken cancellationToken)
    {
        try
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken); // Fetch token from local storage
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/passwordVaults", cancellationToken);
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<List<PasswordVaultDto>>();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
