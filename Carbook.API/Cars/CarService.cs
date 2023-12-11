using Carbook.Shared.Cars;

namespace Carbook.API.Cars;

public class CarService : ICarService
{
    //TODO to database
    private static readonly Dictionary<Guid, Car> _carsCollection = new();
    
    public void CreateCar(Car newCar)
    {
        _carsCollection.Add(newCar.Id, newCar);
    }

    //TODO Result, ErrorOr, OneOf?
    public Car? GetCar(Guid id)
    {
        return _carsCollection.GetValueOrDefault(id);
    }

    public IEnumerable<Car> GetAllCars()
    {
        return _carsCollection.Values;
    }

    public void UpdateCar(Car updatedCar)
    {
        _carsCollection[updatedCar.Id] = updatedCar;
    }

    public void DeleteCar(Guid id)
    {
        _carsCollection.Remove(id);
    }
}