namespace Carbook.Infrastructure.Authentication;

public class JwtOptions
{
    public const string Key = "Jwt";
    
    public string Audience { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Secret { get; set; } = null!;
    public int TokenExpirationInMinutes { get; set; }
}