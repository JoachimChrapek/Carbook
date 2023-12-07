namespace Carbook.API.Cars;

public class CarMileageProvider : ICarMileageProvider
{
    public int GetRandomMileage()
    {
        return Random.Shared.Next(5, 1000000);
    }
}