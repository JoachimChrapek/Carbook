using CarbookWebAPI.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarbookWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("RandomCar")]
    public async Task<IActionResult> GetRandomCar()
    {
        Car car = await _carService.GetRandomCarAsync();

        return Ok(car);
    }
    
    [HttpGet("RandomCarsCollection/{count}")]
    public async Task<IActionResult> GetRandomCarsCollection(int count)
    {
        IEnumerable<Car> carsCollection = await _carService.GetRandomCarsCollectionAsync(count);
        
        return Ok(carsCollection);
    }
}