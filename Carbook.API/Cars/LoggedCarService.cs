using Carbook.API.Logging;
using Carbook.Shared.Cars;

namespace Carbook.API.Cars;

public class LoggedCarService : ICarService
{
    private readonly ICarService _carService;
    private readonly ILogger<ICarService> _logger;

    public LoggedCarService(ICarService carService, ILogger<ICarService> logger)
    {
        _carService = carService;
        _logger = logger;
    }

    public void CreateCar(Car newCar)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(CreateCar)}");
        _carService.CreateCar(newCar);
    }

    public Car? GetCar(Guid id)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(GetCar)}");
        return _carService.GetCar(id);
    }

    public IEnumerable<Car> GetAllCars()
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(GetAllCars)}");
        return _carService.GetAllCars();
    }

    public void UpdateCar(Car updatedCar)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(UpdateCar)}");
        _carService.UpdateCar(updatedCar);
    }

    public void DeleteCar(Guid id)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(DeleteCar)}");
        _carService.DeleteCar(id);
    }
}