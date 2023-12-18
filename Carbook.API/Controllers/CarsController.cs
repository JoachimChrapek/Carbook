using Carbook.API.Extensions;
using Carbook.Application.Services;
using Carbook.Contracts;
using Carbook.Domain.Cars;
using Microsoft.AspNetCore.Mvc;
using DomainCarType = Carbook.Domain.Cars.CarType;

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
    public async Task<CreatedAtActionResult> CreateCar(CreateCarRequest request)
    {
        Car car = new (Guid.NewGuid(), (DomainCarType) request.Type, request.Make, request.Model, request.ProductionDate, request.Mileage, DateTime.UtcNow);
        await _carService.CreateCarAsync(car);

        CarResponse response = car.ToCarResponse();
        
        return CreatedAtAction(nameof(GetCar), new {id = car.Id}, response);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCar(Guid id)
    {
        Car? car = await _carService.GetCarAsync(id);

        if (car == null)
        {
            return NotFound();
        }
        
        CarResponse response = car.ToCarResponse();
        
        return Ok(response);
    }
    
    //TODO change this - this will be problematic with bigger database
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCars()
    {
        IEnumerable<Car> cars = await _carService.GetAllCarsAsync();
        CarsCollectionResponse response = new(cars.Select(c => c.ToCarResponse()));

        return Ok(response);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCar(Guid id, UpdateCarRequest request)
    {
        Car car = new (id, (DomainCarType) request.Type, request.Make, request.Model, request.ProductionDate, request.Mileage, DateTime.UtcNow);
        await _carService.UpdateCarAsync(car);
        
        CarResponse response = car.ToCarResponse();
        
        return CreatedAtAction(nameof(GetCar), new {id = car.Id}, response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        await _carService.DeleteCarAsync(id);
        
        return NoContent();
    }
}