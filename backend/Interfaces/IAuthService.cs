using backend.DTOs;

namespace backend.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto dto);

    Task<string> LoginAsync(LoginDto dto);
}