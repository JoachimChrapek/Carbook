using Carbook.Contracts;

namespace Carbook.WebApp.Cars;

public interface ICarService
{
    Task<CarResponse?> CreateCar(Car car);
    Task<CarResponse?> GetCar(Guid id);
    Task<CarsCollectionResponse?> GetAllCars();
    Task<CarResponse?> UpdateCar(Guid id, Car newCar);
    Task DeleteCar(Guid id);

}