using Carbook.API.Cars;
using Microsoft.Extensions.DependencyInjection;

namespace Carbook.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCarServices();

        return services;
    }
}