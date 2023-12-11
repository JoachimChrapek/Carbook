using Carbook.API.Cars;
using Carbook.Shared.Cars;
using Carbook.Shared.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Carbook.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase
{
    private readonly ICarService _carService;

    public CarsController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpPost]
    public IActionResult CreateCar(CreateCarRequest request)
    {
        Car car = new (Guid.NewGuid(), request.Make, request.Model, request.ProductionDate, request.Mileage, DateTime.UtcNow);
        _carService.CreateCar(car);
        
        CarResponse response = CarResponse.From(car);
        
        return CreatedAtAction(nameof(GetCar), new {id = car.Id}, response);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetCar(Guid id)
    {
        Car? car = _carService.GetCar(id);

        if (car == null)
        {
            return NotFound();
        }
        
        CarResponse response = CarResponse.From(car);
        
        return Ok(response);
    }
    
    [HttpGet("all")]
    public IActionResult GetAllCars()
    {
        IEnumerable<Car> cars = _carService.GetAllCars();
        CarsCollectionResponse response = new(cars.Select(c => CarResponse.From(c)));

        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult UpdateCar(Guid id, UpdateCarRequest request)
    {
        Car car = new (id, request.Make, request.Model, request.ProductionDate, request.Mileage, DateTime.UtcNow);
        _carService.UpdateCar(car);
        
        CarResponse response = CarResponse.From(car);
        
        return CreatedAtAction(nameof(GetCar), new {id = car.Id}, response);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteCar(Guid id)
    {
        _carService.DeleteCar(id);
        
        return NoContent();
    }
}