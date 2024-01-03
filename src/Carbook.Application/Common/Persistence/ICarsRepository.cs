using Carbook.Domain.Cars;

namespace Carbook.Application.Common.Persistence;

public interface ICarsRepository
{
    Task AddCarAsync(Car car);
    Task UpdateCarAsync(Car car);
    Task DeleteCarAsync(Guid id);
    
    Task<Car?> GetCarAsync(Guid id);
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<bool> IsCarAddedAsync(Guid id);
}