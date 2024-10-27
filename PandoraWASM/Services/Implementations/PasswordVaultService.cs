using Blazored.LocalStorage;
using Pandora.Shared.DTOs.PasswordVaultDTOs;
using PandoraWASM.Services.Interfaces;

namespace PandoraWASM.Services.Implementations;

public class PasswordVaultService : BaseHttpClientService, IPasswordVaultService
{
    public PasswordVaultService(HttpClient httpClient, ILocalStorageService localStorageService)
        : base(httpClient, localStorageService)
    {
    }

    public async Task<PasswordVaultDto?> GetPasswordVaultAsync(Guid passwordVaultId, CancellationToken cancellationToken)
    {
        return await GetAsync<PasswordVaultDto>($"api/passwordVaults/{passwordVaultId}", cancellationToken);
    }

    public async Task<IList<PasswordVaultDto>?> GetPasswordVaultsAsync(CancellationToken cancellationToken)
    {
        return await GetAsync<List<PasswordVaultDto>>("api/passwordVaults", cancellationToken);
    }

    public async Task<(bool Success, string? ErrorMessage)> AddAsync(PasswordVaultAddDto passwordVaultAddDto, CancellationToken cancellationToken)
    {
        var response = await PostAsync("api/passwordVaults", passwordVaultAddDto, cancellationToken);
        return await ProcessHttpResponse(response);
    }

    public async Task<(bool Success, string? ErrorMessage)> UpdateAsync(PasswordVaultUpdateDto passwordVaultUpdateDto, CancellationToken cancellationToken)
    {
        var response = await PutAsync("api/passwordVaults", passwordVaultUpdateDto, cancellationToken);
        return await ProcessHttpResponse(response);
    }

    public async Task<(bool Success, string? ErrorMessage)> DeleteAsync(Guid passwordVaultId, CancellationToken cancellationToken)
    {
        var response = await DeleteAsync($"api/passwordVaults/{passwordVaultId}", cancellationToken);
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
