using Carbook.Application.Common.Persistence;
using Carbook.Domain.Cars;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Cars.Queries;

public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, Result<IEnumerable<Car>>>
{
    private readonly ICarsRepository _carsRepository;

    public GetAllCarsQueryHandler(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public async Task<Result<IEnumerable<Car>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Car> cars = await _carsRepository.GetAllCarsAsync();
        return Result<IEnumerable<Car>>.From(cars);
    }
}