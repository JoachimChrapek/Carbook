using Carbook.Application.Common.Persistence;
using Carbook.Domain.Authentication;
using Carbook.Domain.Users;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Authentication.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public LoginQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetUserByUsernameAsync(request.Username);

        if (user == null || user.IsPasswordCorrect(request.Password, _passwordHasher) == false)
        {
            return AuthenticationErrors.InvalidCredentials;
        }

        //TODO return token
        return new AuthenticationResult(user, "TOKEN");
    }
}