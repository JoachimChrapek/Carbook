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
    private readonly IJwtTokenGenerator _tokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetUserByUsernameAsync(request.Username);

        if (user == null || user.IsPasswordCorrect(request.Password, _passwordHasher) == false)
        {
            return AuthenticationErrors.InvalidCredentials;
        }

        string token = _tokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}