using Carbook.Shared.Cars;

namespace Carbook.WebApp.Cars;

public interface ICarService
{
    Task<IEnumerable<Car>?> GetRandomCarsCollectionAsync(int count);
}