using FazApp.Result;
using MediatR;

namespace Carbook.Application.Cars.Commands;

public record DeleteCarCommand(Guid Id) : IRequest<Result>;