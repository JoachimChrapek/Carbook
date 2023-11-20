using Microsoft.AspNetCore.Mvc;

namespace CarbookWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private static readonly string[] Models = new[] {
        "BMW", "Audi", "Ford", "KIA", "Toyota"
    };
    
    private readonly ILogger<CarController> _logger;
    
    public CarController(ILogger<CarController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("Car")]
    public Car GetCar()
    {
        return GetRandomCar();
    }
    
    [HttpGet]
    [Route("CarsCollection/{count}")]
    public IEnumerable<Car> GetCarsCollection(int count)
    {
        return Enumerable.Range(1, count).Select(_ => GetRandomCar());
    }

    private Car GetRandomCar()
    {
        return new Car {
            Model = Models[Random.Shared.Next(Models.Length)],
            Mileage = Random.Shared.Next(5, 1000000),
            ProductionDate = GetRandomProductionDate()
        };
    }
    
    private DateOnly GetRandomProductionDate()
    {
        DateTime start = new (1995, 1, 1);
        int range = (DateTime.Today - start).Days;

        return DateOnly.FromDateTime(start.AddDays(Random.Shared.Next(range)));
    }
}