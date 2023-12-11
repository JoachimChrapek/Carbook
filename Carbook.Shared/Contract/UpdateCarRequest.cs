namespace Carbook.Shared.Contract;

public class UpdateCarRequest
{
    public string Make { get; }
    public string Model { get; }
    public DateOnly ProductionDate { get; }
    public int Mileage { get; }
    
    public UpdateCarRequest(string make, string model, DateOnly productionDate, int mileage)
    {
        Make = make;
        Model = model;
        ProductionDate = productionDate;
        Mileage = mileage;
    }
}