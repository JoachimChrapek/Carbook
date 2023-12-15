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

    public void CreateCar(Car newCar)
    {
        _carsRepository.Add(newCar);
    }

    //TODO Result, ErrorOr, OneOf?
    public Car? GetCar(Guid id)
    {
        Car? car = _carsRepository.Get(id);

        if (car == null)
        {
            // TODO NotFound
            return null;
        }

        return car;
    }

    public IEnumerable<Car> GetAllCars()
    {
        return _carsRepository.GetAll();
    }

    public void UpdateCar(Car updatedCar)
    {
        if (_carsRepository.IsCarAdded(updatedCar.Id))
        {
            _carsRepository.Update(updatedCar);
        }
        else
        {
            _carsRepository.Add(updatedCar);
        }
    }

    public void DeleteCar(Guid id)
    {
        _carsRepository.Delete(id);
        
        // Car? car = _carsDbContext.Cars.Find(id);
        //
        // if (car == null)
        // {
        //     // TODO NotFound
        //     return;
        // }
        //
        // _carsDbContext.Remove(car);
        // _carsDbContext.SaveChanges();
    }
}