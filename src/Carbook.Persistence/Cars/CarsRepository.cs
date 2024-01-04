using Carbook.Application.Common.Persistence;
using Carbook.Domain.Cars;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistence.Cars;

public class CarsRepository : ICarsRepository
{
    private readonly CarbookDbContext _carbookDbContext;

    public CarsRepository(CarbookDbContext carbookDbContext)
    {
        _carbookDbContext = carbookDbContext;
    }

    public async Task AddCarAsync(Car car)
    {
        await _carbookDbContext.Cars.AddAsync(car);
        await _carbookDbContext.SaveChangesAsync();
    }

    public async Task UpdateCarAsync(Car car)
    {
        bool isCarAlreadyAdded = await _carbookDbContext.Cars.AnyAsync(c => c.Id == car.Id);
        
        if (isCarAlreadyAdded)
        {
            _carbookDbContext.Cars.Update(car);
        }
        else
        {
            await _carbookDbContext.Cars.AddAsync(car);
        }

        await _carbookDbContext.SaveChangesAsync();
    }

    public async Task DeleteCarAsync(Guid id)
    {
        Car? car = await _carbookDbContext.Cars.FindAsync(id);

        if (car == null)
        {
            //TODO info/error
            return;
        }
        
        _carbookDbContext.Remove(car);
        await _carbookDbContext.SaveChangesAsync();
    }

    public async Task<Car?> GetCarAsync(Guid id)
    {
        Car? car = await _carbookDbContext.Cars.FindAsync(id);
        
        //TODO error if null
        return car;
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _carbookDbContext.Cars.ToListAsync();
    }

    public Task<bool> IsCarAddedAsync(Guid id)
    {
        return _carbookDbContext.Cars.AnyAsync(c => c.Id == id);
    }
}