using Carbook.Application.Common.Persistence;
using Carbook.Application.Errors.Cars;
using Carbook.Domain.Cars;
using FazApp.Result;
using MediatR;

namespace Carbook.Application.Cars.Commands;

public class UpdateCarCommandHandle : IRequestHandler<UpdateCarCommand, Result<Car>>
{
    private readonly ICarsRepository _carsRepository;

    public UpdateCarCommandHandle(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }
    
    public async Task<Result<Car>> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        if (await _carsRepository.IsCarAddedAsync(request.Id) == false)
        {
            return CarsErrorrs.CarNotFound(request.Id);
        }
        
        Car updatedCar = new (request.Id, request.Type, request.Make, request.Model, request.ProductionDate, request.Mileage, DateTime.UtcNow);
        await _carsRepository.UpdateCarAsync(updatedCar);
        return updatedCar;
    }
}