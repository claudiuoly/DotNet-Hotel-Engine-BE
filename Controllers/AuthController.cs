using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuraStay.Api.Constants;
using AuraStay.Api.Entities;
using AuraStay.Api.Models;
using AuraStay.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuraStay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto request)
        {
            var user = await authService.RegisterAsync(request);

            if (user is null)
                return BadRequest("Username, email or phone already in use.");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(LoginDto request)
        {
            var result = await authService.LoginAsync(request);

            if (result is null)
                return BadRequest("Invalid username/email/phone or password.");

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokenAsync(request);
            if(result is null || result.AccessToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh token.");
            
            return Ok(result);
        }

        [Authorize]
        [HttpGet("verifyAuth")]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            
            return Ok("You are authenticated!");
        }
        
        [Authorize(Roles = $"{UserRoles.Admin},{UserRoles.SuperAdmin}")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are authenticated!");
        }

        [Authorize(Roles = UserRoles.SuperAdmin)]
        [HttpGet("superadmin-only")]
        public IActionResult SuperAdminOnlyEndpoint()
        {
            return Ok("SuperAdmin only.");
        }
    }
}
 