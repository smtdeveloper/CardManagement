using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Domain.Entities.UserEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BotanoDemoCardManagement.Persistence.Repositories;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly string _secretKey;
    private readonly string _issuer;
    private readonly string _audience;
  
    public JwtTokenGenerator(IConfiguration configuration)
    {
        _secretKey = configuration["JWT:Secret"];
        _issuer = configuration["JWT:Issuer"];
        _audience = configuration["JWT:Audience"];
    }

    public string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}