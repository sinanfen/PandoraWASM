using Pandora.Shared.DTOs.UserDTOs;

namespace PandoraWASM.Responses;

public class RegisterResponse
{
    public bool Success { get; set; }
    public UserDto UserDto { get; set; }
    public string Message { get; set; }
}
