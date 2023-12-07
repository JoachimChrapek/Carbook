using Carbook.Shared.Cars;

namespace Carbook.API.Cars;

public interface ICarProvider
{
    Car GetRandomCar();
}