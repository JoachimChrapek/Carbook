using FazApp.Result;
using MediatR;

namespace Carbook.Application.Authentication.Queries;

public record LoginQuery(string Username, string Password) : IRequest<Result<AuthenticationResult>>;