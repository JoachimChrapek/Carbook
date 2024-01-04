using FazApp.Result;
using MediatR;

namespace Carbook.Application.Authentication.Commands;

public record RegisterCommand(string Username, string Password) : IRequest<Result>;