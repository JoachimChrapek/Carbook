using System.Text;

namespace Carbook.WebApp.Cars;

public class Car
{
    public Guid Id { get; private set; }

    public string Make { get; private set; }
    public string Model { get; private set; }
    public DateOnly ProductionDate { get; private set; }
    public int Mileage { get; private set; }

    public DateTime LastModifiedDateTime { get; private set; }

    private Car() { }

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