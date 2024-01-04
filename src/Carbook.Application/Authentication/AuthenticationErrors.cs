using FazApp.Result;

namespace Carbook.Application.Authentication;

public static class AuthenticationErrors
{
    public static Error UserAlreadyExists = new(ErrorType.Conflict, "Authentication.UserAlreadyExists", $"User already exists");
    public static Error InvalidCredentials = new(ErrorType.Unauthorized, "Authentication.InvalidCredentials", "Invalid credentials");
}