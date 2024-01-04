using Carbook.Application.Authentication;
using Carbook.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Carbook.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtOptions _options;

    public JwtTokenGenerator(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public string GenerateToken(User user)
    {
        SymmetricSecurityKey key = new (Encoding.UTF8.GetBytes(_options.Secret));
        SigningCredentials credentials = new (key, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new() {
            new Claim("id", user.Id.ToString()),
            new Claim("username", user.Username)
        };
        
        JwtSecurityToken token = new (
            _options.Issuer, 
            _options.Audience, 
            claims, 
            expires: DateTime.UtcNow.AddMinutes(_options.TokenExpirationInMinutes), 
            signingCredentials: credentials);
        
        string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
        
        return tokenStr;
    }
}