using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CarbookWebAPI.Cars;

public static class CarServiceRegistration
{
    public static IServiceCollection AddCarServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICarService, CarService>();
        services.TryAddScoped<ICarProvider, CarProvider>();
        services.TryAddScoped<ICarModelProvider, CarModelProvider>();
        services.TryAddScoped<ICarMileageProvider, CarMileageProvider>();
        services.TryAddScoped<ICarProductionDateProvider, CarProductionDateProvider>();

        return services;
    }
}