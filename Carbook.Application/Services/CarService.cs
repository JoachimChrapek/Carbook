using Carbook.Application.Common.Persistence;
using Carbook.Domain.Cars;
using FazApp.Result;

namespace Carbook.Application.Services;

public class CarService : ICarService
{
    private readonly ICarsRepository _carsRepository;

    public CarService(ICarsRepository carsRepository)
    {
        _carsRepository = carsRepository;
    }

    public async Task<Result> CreateCarAsync(Car newCar)
    {
        await _carsRepository.AddCarAsync(newCar);
        return Result.Success;
    }

    public async Task<Result<Car>> GetCarAsync(Guid id)
    {
        Car? car = await _carsRepository.GetCarAsync(id);

        if (car == null)
        {
            // TODO NotFound error
            return null;
        }

        return car;
    }

    public async Task<Result<IEnumerable<Car>>> GetAllCarsAsync()
    {
        IEnumerable<Car> cars = await _carsRepository.GetAllCarsAsync();
        return Result<IEnumerable<Car>>.From(cars);
    }

    public async Task<Result> UpdateCarAsync(Car updatedCar)
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
        
        return Result.Success;
    }

    public async Task<Result> DeleteCarAsync(Guid id)
    {
        await _carsRepository.DeleteCarAsync(id);
        return Result.Success;
    }
}