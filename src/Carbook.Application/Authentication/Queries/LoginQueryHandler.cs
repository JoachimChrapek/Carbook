using Carbook.Application.Common.Persistence;
using Carbook.Domain.Users;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Authentication.Queries;

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<AuthenticationResult>>
{
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetUserByUsernameAsync(request.Username);

        if (user == null || user.IsPasswordCorrect(request.Password) == false)
        {
            return AuthenticationErrors.InvalidCredentials;
        }

        //TODO return token
        return new AuthenticationResult(user, "TOKEN");
    }
}