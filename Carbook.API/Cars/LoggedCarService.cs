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

    public async Task<Car> GetRandomCarAsync()
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(GetRandomCarAsync)}");
        return await _carService.GetRandomCarAsync();
    }

    public async Task<IEnumerable<Car>> GetRandomCarsCollectionAsync(int count)
    {
        using IDisposable _ = _logger.TimedOperation(LogLevel.Information, $"{nameof(GetRandomCarsCollectionAsync)}");
        return await _carService.GetRandomCarsCollectionAsync(count);
    }
}