using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services;
using Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Presentation.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<User> userManager, IConfiguration configuration, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] UserForRegistrationDto dto)
        {
            var user = new User { UserName = dto.Username, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Admin");
            return StatusCode(201);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegistrationDto dto)
        {
            var user = new User { UserName = dto.Username, Email = dto.Email };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return Unauthorized("Invalid credentials.");

            var token = _tokenService.GenerateAccessToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });

            var expiration = DateTime.UtcNow.AddMinutes(60);

            return Ok(new AuthResponseDto
            {
                Token = token.Result,
                Expiration = expiration
            });
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                return Unauthorized();

            // (Optional) Validate refresh token against stored user data in DB

            // For demo: Assume valid, generate a dummy user (or fetch from DB)
            var user = await _userManager.FindByNameAsync("admin"); // Replace with dynamic lookup
            if (user == null)
                return Unauthorized();

            var newAccessToken = _tokenService.GenerateAccessToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            Response.Cookies.Append("refreshToken", newRefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
            });

            return Ok(new { Token = newAccessToken, Expiration = DateTime.UtcNow.AddMinutes(60) });
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("refreshToken");
            return NoContent();
        }

        private string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
