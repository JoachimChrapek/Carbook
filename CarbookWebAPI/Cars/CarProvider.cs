namespace CarbookWebAPI.Cars;

public class CarProvider : ICarProvider
{
    private readonly ICarModelProvider _modelProvider;
    private readonly ICarMileageProvider _mileageProvider;
    private readonly ICarProductionDateProvider _productionDateProvider;

    private readonly ILogger<CarProvider> _logger;
    public CarProvider(ICarModelProvider modelProvider, ICarMileageProvider mileageProvider, ICarProductionDateProvider productionDateProvider, ILogger<CarProvider> logger)
    {
        _modelProvider = modelProvider;
        _mileageProvider = mileageProvider;
        _productionDateProvider = productionDateProvider;
        _logger = logger;
    }

    public Car GetRandomCar()
    {
        Car car = new()  {
            Model = _modelProvider.GetRandomModel(),
            Mileage = _mileageProvider.GetRandomMileage(),
            ProductionDate = _productionDateProvider.GetRandomProductionDate()
        };
        
        _logger.LogInformation($"Created new random car\n {car}");

        return car;
    }
}