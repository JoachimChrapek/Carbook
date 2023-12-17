using Carbook.Domain.Cars;

namespace Carbook.Application.Services;

public interface ICarService
{
    Task CreateCarAsync(Car newCar);
    Task<Car?> GetCarAsync(Guid id);
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task UpdateCarAsync(Car updatedCar);
    Task DeleteCarAsync(Guid id);
}