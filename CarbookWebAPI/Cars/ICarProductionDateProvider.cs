namespace CarbookWebAPI.Cars;

public interface ICarProductionDateProvider 
{
    public DateOnly GetRandomProductionDate();
}