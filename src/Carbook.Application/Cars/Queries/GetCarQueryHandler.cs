using Carbook.Application.Common.Persistence;
using Carbook.Application.Errors.Cars;
using Carbook.Domain.Cars;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Cars.Queries;

public class GetCarQueryHandler : IRequestHandler<GetCarQuery, Result<Car>>
{
    private readonly ICarsRepository _carsRepository;

    public GetCarQueryHandler(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }
    
    public async Task<Result<Car>> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        Car? car = await _carsRepository.GetCarAsync(request.Id);

        if (car == null)
        {
            return CarsErrorrs.CarNotFound(request.Id);
        }

        return car;
    }
}