using Carbook.Domain.Users;

namespace Carbook.Application.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}