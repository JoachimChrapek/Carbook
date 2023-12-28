using Carbook.Application.Logging;
using Carbook.Domain.Cars;
using FazApp.Result;
using Microsoft.Extensions.Logging;

namespace Carbook.Application.Services;

//TODO maybe not in application layer?
public class LoggedCarService : ICarService
{
    private readonly ICarService _carService;
    private readonly ILogger<ICarService> _logger;

    public LoggedCarService(ICarService carService, ILogger<ICarService> logger)
    {
        _carService = carService;
        _logger = logger;
    }

    public async Task<Result> CreateCarAsync(Car newCar)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(CreateCarAsync)}");
        return await _carService.CreateCarAsync(newCar);
    }

    public async Task<Result<Car>> GetCarAsync(Guid id)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(GetCarAsync)}");
        return await _carService.GetCarAsync(id);
    }

    public Task<Result<IEnumerable<Car>>> GetAllCarsAsync()
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(GetAllCarsAsync)}");
        return _carService.GetAllCarsAsync();
    }

    public Task<Result> UpdateCarAsync(Car updatedCar)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(UpdateCarAsync)}");
        return _carService.UpdateCarAsync(updatedCar);
    }

    public Task<Result> DeleteCarAsync(Guid id)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(DeleteCarAsync)}");
        return _carService.DeleteCarAsync(id);
    }
}