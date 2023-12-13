using Carbook.API.Database;
using Carbook.Shared.Cars;

namespace Carbook.API.Cars;

public class CarService : ICarService
{
    private readonly CarsDbContext _carsDbContext;

    public CarService(CarsDbContext carsDbContext)
    {
        _carsDbContext = carsDbContext;
    }

    public void CreateCar(Car newCar)
    {
        _carsDbContext.Add(newCar);
        _carsDbContext.SaveChanges();
    }

    //TODO Result, ErrorOr, OneOf?
    public Car? GetCar(Guid id)
    {
        Car? car = _carsDbContext.Cars.Find(id);

        if (car == null)
        {
            // TODO NotFound
            return null;
        }

        return car;
    }

    public IEnumerable<Car> GetAllCars()
    {
        return _carsDbContext.Cars.AsEnumerable();
    }

    public void UpdateCar(Car updatedCar)
    {
        if (_carsDbContext.Cars.Any(c => c.Id == updatedCar.Id))
        {
            _carsDbContext.Cars.Update(updatedCar);
        }
        else
        {
            _carsDbContext.Cars.Add(updatedCar);
        }

        _carsDbContext.SaveChanges();
    }

    public void DeleteCar(Guid id)
    {
        Car? car = _carsDbContext.Cars.Find(id);

        if (car == null)
        {
            // TODO NotFound
            return;
        }

        _carsDbContext.Remove(car);
        _carsDbContext.SaveChanges();
    }
}