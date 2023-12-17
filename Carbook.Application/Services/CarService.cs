using Carbook.Application.Common.Persistence;
using Carbook.Domain.Cars;

namespace Carbook.Application.Services;

public class CarService : ICarService
{
    private readonly ICarsRepository _carsRepository;

    public CarService(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public Task CreateCarAsync(Car newCar)
    {
        return _carsRepository.AddCarAsync(newCar);
    }

    //TODO Result, ErrorOr, OneOf?
    public async Task<Car?> GetCarAsync(Guid id)
    {
        Car? car = await _carsRepository.GetCarAsync(id);

        if (car == null)
        {
            // TODO NotFound
            return null;
        }

        return car;
    }

    public Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return _carsRepository.GetAllCarsAsync();
    }

    public async Task UpdateCarAsync(Car updatedCar)
    {
        bool isCarAlreadyAdded = await _carsRepository.IsCarAddedAsync(updatedCar.Id);

        if (isCarAlreadyAdded)
        {
            await _carsRepository.UpdateCarAsync(updatedCar);
        }
        else
        {
            await _carsRepository.AddCarAsync(updatedCar);
        }
    }

    public Task DeleteCarAsync(Guid id)
    {
        return _carsRepository.DeleteCarAsync(id);
    }
}