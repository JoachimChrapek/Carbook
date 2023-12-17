using Carbook.Application.Logging;
using Carbook.Domain.Cars;
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

    public async Task CreateCarAsync(Car newCar)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(CreateCarAsync)}");
        await _carService.CreateCarAsync(newCar);
    }

    public Task<Car?> GetCarAsync(Guid id)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(GetCarAsync)}");
        return _carService.GetCarAsync(id);
    }

    public Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(GetAllCarsAsync)}");
        return _carService.GetAllCarsAsync();
    }

    public Task UpdateCarAsync(Car updatedCar)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(UpdateCarAsync)}");
        return _carService.UpdateCarAsync(updatedCar);
    }

    public Task DeleteCarAsync(Guid id)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(DeleteCarAsync)}");
        return _carService.DeleteCarAsync(id);
    }
}