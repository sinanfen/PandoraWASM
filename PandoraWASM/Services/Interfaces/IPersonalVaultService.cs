using Pandora.Shared.DTOs.PersonalVaultDTOs;

namespace PandoraWASM.Services.Interfaces;

public interface IPersonalVaultService
{
    Task<PersonalVaultDto?> GetPersonalVault(Guid personalVaultId, CancellationToken cancellationToken);
    Task<IList<PersonalVaultDto>?> GetPersonalVaults(CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> AddPersonalVault(PersonalVaultAddDto personalVaultAddDto, CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> UpdatePersonalVault(PersonalVaultUpdateDto personalVaultUpdateDto, CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> DeletePersonalVault(Guid personalVaultId, CancellationToken cancellationToken);
}
