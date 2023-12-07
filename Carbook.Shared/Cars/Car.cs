using System.Text;

namespace Carbook.Shared.Cars;

public class Car
{
    public string Model { get; set; }
    public int Mileage { get; set; }
    public DateOnly ProductionDate { get; set; }

    public override string ToString()
    {
        StringBuilder builder = new();
        builder.AppendLine($"{nameof(Model)}: {Model}");
        builder.AppendLine($"{nameof(Mileage)}: {Mileage}");
        builder.AppendLine($"{nameof(ProductionDate)}: {ProductionDate:O}");
        
        return builder.ToString();
    }
}