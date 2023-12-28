using Carbook.Domain.Cars;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Cars.Queries;

public record GetAllCarsQuery : IRequest<Result<IEnumerable<Car>>>;