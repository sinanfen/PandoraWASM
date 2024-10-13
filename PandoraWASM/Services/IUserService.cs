using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Services;

public interface IUserService
{
    Task<UserDto> GetUserAsync(Guid userId);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<(bool Success, string? ErrorMessage)> UpdateCorporateUserAsync(CorporateUserUpdateDto corporateUserUpdateDto);
    Task<(bool Success, string? ErrorMessage)> UpdateIndividualUserAsync(IndividualUserUpdateDto individualUserUpdateDto);
    Task<bool> DeleteUserAsync(Guid userId);
}