using AuraStay.Api.Entities;
using AuraStay.Api.Models;

namespace AuraStay.Api.Services;

public interface IAuthService
{
    Task<User?> RegisterAsync(RegisterDto request);
    Task<TokenResponseDto?> LoginAsync(LoginDto request);
    Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
}