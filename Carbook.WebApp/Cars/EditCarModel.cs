using Carbook.Contracts;

namespace Carbook.WebApp.Cars;

public class EditCarModel
{
    public Guid Id { get; set; }
    
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public DateOnly ProductionDate { get; set; }
    public int Mileage { get; set; }

    public DateTime LastModifiedDateTime { get; set; } = DateTime.Now;

    public Car ToCar()
    {
        return new(Id, Make, Model, ProductionDate, Mileage, LastModifiedDateTime);
    }

    public static EditCarModel From(Car car)
    {
        return new EditCarModel {
            Id = car.Id,
            Make = car.Make,
            Model = car.Model,
            ProductionDate = car.ProductionDate,
            Mileage = car.Mileage,
            LastModifiedDateTime = car.LastModifiedDateTime
        };
    }
    
    public static EditCarModel From(CarResponse car)
    {
        return new EditCarModel {
            Id = car.Id,
            Make = car.Make,
            Model = car.Model,
            ProductionDate = car.ProductionDate,
            Mileage = car.Mileage,
            LastModifiedDateTime = car.LastModifiedDateTime
        };
    }
}