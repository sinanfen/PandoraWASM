using Blazored.LocalStorage;
using Pandora.Shared.DTOs.PersonalVaultDTOs;
using PandoraWASM.Services.Interfaces;

namespace PandoraWASM.Services.Implementations;

public class PersonalVaultService : BaseHttpClientService, IPersonalVaultService
{
    public PersonalVaultService(HttpClient httpClient, ILocalStorageService localStorageService)
        : base(httpClient, localStorageService)
    {
    }

    public async Task<PersonalVaultDto?> GetPersonalVault(Guid personalVaultId, CancellationToken cancellationToken)
    {
        return await GetAsync<PersonalVaultDto>($"api/personalVaults/{personalVaultId}", cancellationToken);
    }

    public async Task<IList<PersonalVaultDto>?> GetPersonalVaults(CancellationToken cancellationToken)
    {
        return await GetAsync<List<PersonalVaultDto>>("api/personalVaults", cancellationToken);
    }

    public async Task<(bool Success, string? ErrorMessage)> AddPersonalVault(PersonalVaultAddDto personalVaultAddDto, CancellationToken cancellationToken)
    {
        var response = await PostAsync("api/personalVaults", personalVaultAddDto, cancellationToken);
        return await ProcessHttpResponse(response);
    }

    public async Task<(bool Success, string? ErrorMessage)> UpdatePersonalVault(Guid personalVaultId, PersonalVaultUpdateDto personalVaultUpdateDto, CancellationToken cancellationToken)
    {
        var response = await PutAsync($"api/personalVaults/{personalVaultId}", personalVaultUpdateDto, cancellationToken);
        return await ProcessHttpResponse(response);
    }

    public async Task<(bool Success, string? ErrorMessage)> DeletePersonalVault(Guid personalVaultId, CancellationToken cancellationToken)
    {
        var response = await DeleteAsync($"api/personalVaults/{personalVaultId}", cancellationToken);
        return await ProcessHttpResponse(response);
    }

    private async Task<(bool Success, string? ErrorMessage)> ProcessHttpResponse(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
            return (true, null);

        var errorMessage = await response.Content.ReadAsStringAsync();
        return (false, errorMessage);
    }
}
