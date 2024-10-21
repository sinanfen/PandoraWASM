using Pandora.Shared.DTOs.PasswordVaultDTOs;

namespace PandoraWASM.Services.Interfaces;

public interface IPasswordVaultService
{
    Task<PasswordVaultDto> GetPasswordVault(Guid passwordVaultId, CancellationToken cancellationToken);
    Task<IList<PasswordVaultDto>> GetPasswordVaults(CancellationToken cancellationToken);
}
