using Carbook.API.Extensions;
using Carbook.Application.Cars.Commands;
using Carbook.Application.Cars.Queries;
using Carbook.Contracts;
using Carbook.Domain.Cars;
using FazApp.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainCarType = Carbook.Domain.Cars.CarType;

namespace Carbook.API.Controllers;

[Route("[controller]")]
public class CarsController : ApiController
{
    private readonly IMediator _mediator;

    public CarsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarRequest request)
    {
        CreateCarCommand createCarCommand = new ((DomainCarType)request.Type, request.Make, request.Model, request.ProductionDate, request.Mileage);
        Result<Car> createCarResult = await _mediator.Send(createCarCommand);
        
        return createCarResult.Match(
            car => CreatedAtAction(nameof(GetCar), new {id = car.Id}, car.ToCarResponse()),
            Problem);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCar(Guid id)
    {
        GetCarQuery getCarQuery = new (id);
        Result<Car> getCarResult = await _mediator.Send(getCarQuery);

        return getCarResult.Match(
            car => Ok(car.ToCarResponse()),
            Problem);
    }
    
    //TODO change this - this will be problematic with bigger database
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCars()
    {
        GetAllCarsQuery getAllCarsQuery = new ();
        Result<IEnumerable<Car>> getAllCarsResult = await _mediator.Send(getAllCarsQuery);

        return getAllCarsResult.Match(
            cars => Ok(new CarsCollectionResponse(cars.Select(c => c.ToCarResponse()))),
            Problem);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCar(Guid id, UpdateCarRequest request)
    {
        UpdateCarCommand updateCarCommand = new (id, (DomainCarType)request.Type, request.Make, request.Model, request.ProductionDate, request.Mileage);
        Result<Car> updateCarResult = await _mediator.Send(updateCarCommand);
        
        return updateCarResult.Match(
            car => Ok(car.ToCarResponse()),
            Problem);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        DeleteCarCommand deleteCarCommand = new(id);
        Result deleteCarResult = await _mediator.Send(deleteCarCommand);

        return deleteCarResult.Match(
            NoContent,
            Problem);
    }
}