using Carbook.Application.Common.Persistence;
using Carbook.Domain.Cars;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistence.Cars;

public class CarsRepository : ICarsRepository
{
    private readonly CarsDbContext _carsDbContext;

    public CarsRepository(CarsDbContext carsDbContext)
    {
        _carsDbContext = carsDbContext;
    }

    public async Task AddCarAsync(Car car)
    {
        await _carsDbContext.Cars.AddAsync(car);
        await _carsDbContext.SaveChangesAsync();
    }

    public async Task UpdateCarAsync(Car car)
    {
        bool isCarAlreadyAdded = await _carsDbContext.Cars.AnyAsync(c => c.Id == car.Id);
        
        if (isCarAlreadyAdded)
        {
            _carsDbContext.Cars.Update(car);
        }
        else
        {
            await _carsDbContext.Cars.AddAsync(car);
        }

        await _carsDbContext.SaveChangesAsync();
    }

    public async Task DeleteCarAsync(Guid id)
    {
        Car? car = await _carsDbContext.Cars.FindAsync(id);

        if (car == null)
        {
            //TODO info/error
            return;
        }
        
        _carsDbContext.Remove(car);
        await _carsDbContext.SaveChangesAsync();
    }

    public async Task<Car?> GetCarAsync(Guid id)
    {
        Car? car = await _carsDbContext.Cars.FindAsync(id);
        
        //TODO error if null
        return car;
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _carsDbContext.Cars.ToListAsync();
    }

    public Task<bool> IsCarAddedAsync(Guid id)
    {
        return _carsDbContext.Cars.AnyAsync(c => c.Id == id);
    }
}