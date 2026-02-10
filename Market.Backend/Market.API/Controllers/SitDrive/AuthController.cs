using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Market.API.Controllers.SitDrive;

[ApiController]
[Route("api/sitdrive/auth")]
public sealed class AuthController(IConfiguration configuration) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto request)
    {
        if (request.Username != "admin" || request.Password != "Admin123!")
        {
            return Unauthorized(new { message = "Neispravni kredencijali." });
        }

        var jwtSection = configuration.GetSection("Jwt");
        var issuer = jwtSection["Issuer"];
        var audience = jwtSection["Audience"];
        var key = jwtSection["Key"];

        if (string.IsNullOrWhiteSpace(issuer) || string.IsNullOrWhiteSpace(audience) || string.IsNullOrWhiteSpace(key))
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                new { message = "JWT konfiguracija nije ispravna." });
        }

        var expiresAt = DateTime.UtcNow.AddMinutes(60);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, request.Username),
            new Claim(JwtRegisteredClaimNames.UniqueName, request.Username),
            new Claim(ClaimTypes.Name, request.Username)
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expiresAt,
            signingCredentials: signingCredentials);

        var token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        return Ok(new LoginResponseDto(token, expiresAt, request.Username));
    }
}

public sealed record LoginRequestDto(string Username, string Password);
public sealed record LoginResponseDto(string Token, DateTime ExpiresAt, string Username);
