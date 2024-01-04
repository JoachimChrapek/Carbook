using Carbook.Application.Authentication;
using Carbook.Application.Authentication.Commands;
using Carbook.Application.Authentication.Queries;
using Carbook.Contracts.Authentication;
using FazApp.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.API.Controllers;

[Route("[controller]")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        RegisterCommand command = new(registerRequest.Username, registerRequest.Password);
        
        Result registerResult = await _mediator.Send(command);

        if (registerResult.IsError && registerResult.Errors.First() == AuthenticationErrors.UserAlreadyExists)
        {
            Error firstError = registerResult.Errors.First();
            return Problem(detail: firstError.Description, statusCode: StatusCodes.Status409Conflict);
        }
        
        return registerResult.Match(Ok, Problem);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        LoginQuery query = new(loginRequest.Username, loginRequest.Password);

        Result<AuthenticationResult> loginResult = await _mediator.Send(query);

        if (loginResult.IsError && loginResult.Errors.First() == AuthenticationErrors.InvalidCredentials)
        {
            Error firstError = loginResult.Errors.First();
            return Problem(detail: firstError.Description, statusCode: StatusCodes.Status401Unauthorized);
        }

        return loginResult.Match(
            authResult => Ok(MapToAuthResponse(authResult)),
            Problem);
    }

    private AuthenticationResponse MapToAuthResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(authResult.User.Id, authResult.User.Username, authResult.Token);
    }
}