namespace Carbook.API.Cars;

public class CarService : ICarService
{
    private readonly ICarProvider _carProvider;
    public CarService(ICarProvider carProvider) 
    {
        _carProvider = carProvider;
    }

    public async Task<Car> GetRandomCarAsync()
    {
        return _carProvider.GetRandomCar();
    }

    public async Task<IEnumerable<Car>> GetRandomCarsCollectionAsync(int count)
    {
        return Enumerable.Range(1, count).Select(_ => _carProvider.GetRandomCar());
    }
}