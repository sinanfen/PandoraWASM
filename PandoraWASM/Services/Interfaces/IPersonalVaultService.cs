using Pandora.Shared.DTOs.PersonalVaultDTOs;

namespace PandoraWASM.Services.Interfaces;

public interface IPersonalVaultService
{
    Task<PersonalVaultDto> GetPersonalVault(Guid personalVaultId, CancellationToken cancellationToken);
    Task<IList<PersonalVaultDto>> GetPersonalVaults(CancellationToken cancellationToken);
}
