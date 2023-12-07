using Carbook.Shared.Cars;

namespace Carbook.API.Cars;

public interface ICarService
{
    Task<Car> GetRandomCarAsync();
    Task<IEnumerable<Car>> GetRandomCarsCollectionAsync(int count);
}