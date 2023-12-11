using System.Text;

namespace Carbook.Shared.Cars;

public class Car
{
    public Guid Id { get; }
    
    public string Make { get; }
    public string Model { get; }
    public DateOnly ProductionDate { get; }
    public int Mileage { get; }

    public DateTime LastModifiedDateTime { get; }
    
    public Car(Guid id, string make, string model, DateOnly productionDate, int mileage, DateTime lastModifiedDateTime)
    {
        Id = id;
        Make = make;
        Model = model;
        ProductionDate = productionDate;
        Mileage = mileage;
        LastModifiedDateTime = lastModifiedDateTime;
    }
    
    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine($"{nameof(Id)}: {Id}");
        builder.AppendLine($"{nameof(Make)}: {Make}");
        builder.AppendLine($"{nameof(Model)}: {Model}");
        builder.AppendLine($"{nameof(Mileage)}: {Mileage}");
        builder.AppendLine($"{nameof(ProductionDate)}: {ProductionDate:O}");
        builder.AppendLine($"{nameof(LastModifiedDateTime)}: {LastModifiedDateTime:O}");
        
        return builder.ToString();
    }
}