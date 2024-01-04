using Carbook.Application.Common.Persistence;
using Carbook.Domain.Users;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Authentication.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.UserExists(request.Username))
        {
            return AuthenticationErrors.UserAlreadyExists;
        }

        User user = new (Guid.NewGuid(), request.Username, request.Password);

        await _userRepository.AddUserAsync(user);
        
        return Result.Success;
    }
}