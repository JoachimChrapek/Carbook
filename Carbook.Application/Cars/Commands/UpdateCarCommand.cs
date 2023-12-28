using Carbook.Domain.Cars;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Cars.Commands;

public record UpdateCarCommand(Guid Id, CarType Type, string Make, string Model, DateOnly ProductionDate, int Mileage) : IRequest<Result<Car>>;