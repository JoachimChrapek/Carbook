using Carbook.Domain.Users;

namespace Carbook.Application.Authentication;

public record AuthenticationResult(User User, string Token);