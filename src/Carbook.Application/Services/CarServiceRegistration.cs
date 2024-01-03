using Carbook.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Carbook.API.Cars;

public static class CarServiceRegistration
{
    public static IServiceCollection AddCarServices(this IServiceCollection services)
    {
        services.TryAddScoped<ICarService, CarService>();
        services.TryDecorate<ICarService, LoggedCarService>();

        return services;
    }
}