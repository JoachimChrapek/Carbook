using Carbook.Application.Common.Persistence;
using Carbook.Domain.Authentication;
using Carbook.Domain.Users;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    
    public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.UserExists(request.Username))
        {
            return AuthenticationErrors.UserAlreadyExists;
        }

        string hashedPassword = _passwordHasher.HashPassword(request.Password);

        User user = new (Guid.NewGuid(), request.Username, hashedPassword);

        await _userRepository.AddUserAsync(user);
        
        return Result.Success;
    }
}