namespace CarbookWebAPI.Cars;

public class CarProductionDateProvider : ICarProductionDateProvider
{
    public DateOnly GetRandomProductionDate()
    {
        DateTime start = new (1995, 1, 1);
        int range = (DateTime.Today - start).Days;

        return DateOnly.FromDateTime(start.AddDays(Random.Shared.Next(range)));
    }
}