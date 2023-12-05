namespace CarbookWebAPI.Cars;

public interface ICarService
{
    Task<Car> GetRandomCarAsync();
    Task<IEnumerable<Car>> GetRandomCarsCollectionAsync(int count);
}