using Carbook.Application.Common.Persistence;
using Carbook.Domain.Cars;

namespace Carbook.Persistence.Cars;

public class CarsRepository : ICarsRepository
{
    private readonly CarsDbContext _carsDbContext;

    public CarsRepository(CarsDbContext carsDbContext)
    {
        _carsDbContext = carsDbContext;
    }

    public void Add(Car car)
    {
        _carsDbContext.Cars.Add(car);
        _carsDbContext.SaveChanges();
    }

    public void Update(Car car)
    {
        if (_carsDbContext.Cars.Any(c => c.Id == car.Id))
        {
            _carsDbContext.Cars.Update(car);
        }
        else
        {
            _carsDbContext.Cars.Add(car);
        }

        _carsDbContext.SaveChanges();
        
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        Car? car = _carsDbContext.Cars.Find(id);

        if (car == null)
        {
            //TODO info/error
            return;
        }
        
        _carsDbContext.Remove(car);
        _carsDbContext.SaveChanges();
    }

    public Car? Get(Guid id)
    {
        Car? car = _carsDbContext.Cars.Find(id);
        
        //TODO error if null
        return car;
    }

    public IEnumerable<Car> GetAll()
    {
        return _carsDbContext.Cars.AsEnumerable();
    }

    public bool IsCarAdded(Guid id)
    {
        return _carsDbContext.Cars.Any(c => c.Id == id);
    }
}