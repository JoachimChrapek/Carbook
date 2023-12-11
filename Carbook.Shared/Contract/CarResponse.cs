using Carbook.Shared.Cars;

namespace Carbook.Shared.Contract;

public class CarResponse
{
    public Guid Id { get; }

    public string Make { get; }
    public string Model { get; }
    public DateOnly ProductionDate { get; }
    public int Mileage { get; }

    public DateTime LastModifiedDateTime { get; }

    public CarResponse(Guid id, string make, string model, DateOnly productionDate, int mileage, DateTime lastModifiedDateTime)
    {
        Id = id;
        Make = make;
        Model = model;
        ProductionDate = productionDate;
        Mileage = mileage;
        LastModifiedDateTime = lastModifiedDateTime;
    }

    public static CarResponse From(Car car)
    {
        return new CarResponse(car.Id, car.Make, car.Model, car.ProductionDate, car.Mileage, car.LastModifiedDateTime);
    }
}