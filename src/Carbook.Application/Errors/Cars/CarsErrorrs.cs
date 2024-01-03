using FazApp.Result;

namespace Carbook.Application.Errors.Cars;

public class CarsErrorrs
{
    public static Error CarNotFound(Guid id) => new(ErrorType.NotFound, "Cars.CarNotFound", $"Couldn't find car with given ID - {id}");
}