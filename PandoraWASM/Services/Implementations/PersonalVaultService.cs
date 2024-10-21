using Blazored.LocalStorage;
using Pandora.Shared.DTOs.PersonalVaultDTOs;
using PandoraWASM.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PandoraWASM.Services.Implementations;

public class PersonalVaultService : IPersonalVaultService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorageService;

    public PersonalVaultService(HttpClient httpClient, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _localStorageService = localStorageService;
    }

    public async Task<PersonalVaultDto> GetPersonalVault(Guid personalVaultId, CancellationToken cancellationToken)
    {
        try
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken); // Fetch token from local storage
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/personalVaults/{personalVaultId}", cancellationToken);
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<PersonalVaultDto>();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IList<PersonalVaultDto>> GetPersonalVaults(CancellationToken cancellationToken)
    {
        try
        {
            var token = await _localStorageService.GetItemAsync<string>("authToken", cancellationToken); // Fetch token from local storage
            if (!string.IsNullOrEmpty(token))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/personalVaults", cancellationToken);
            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<List<PersonalVaultDto>>();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
