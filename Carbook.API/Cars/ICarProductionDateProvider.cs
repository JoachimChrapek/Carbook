namespace Carbook.API.Cars;

public interface ICarProductionDateProvider 
{
    public DateOnly GetRandomProductionDate();
}