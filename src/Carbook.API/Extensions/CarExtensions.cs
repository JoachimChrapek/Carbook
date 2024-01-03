using Carbook.Contracts;
using Carbook.Domain.Cars;
using ContractsCarType = Carbook.Contracts.CarType;

namespace Carbook.API.Extensions;

public static class CarExtensions
{
    //TODO better solution (?)
    public static CarResponse ToCarResponse(this Car car)
    {
        return new CarResponse(car.Id, (ContractsCarType)car.Type, car.Make, car.Model, car.ProductionDate, car.Mileage, car.LastModifiedDateTime);
    }
}