using Pandora.Shared.DTOs.PasswordVaultDTOs;

namespace PandoraWASM.Services.Interfaces;

public interface IPasswordVaultService
{
    Task<PasswordVaultDto?> GetPasswordVaultAsync(Guid passwordVaultId, CancellationToken cancellationToken);
    Task<IList<PasswordVaultDto>?> GetPasswordVaultsAsync(CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> AddAsync(PasswordVaultAddDto passwordVaultAddDto, CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> UpdateAsync(PasswordVaultUpdateDto passwordVaultUpdateDto, CancellationToken cancellationToken);
    Task<(bool Success, string? ErrorMessage)> DeleteAsync(Guid passwordVaultId, CancellationToken cancellationToken);
}
