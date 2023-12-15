using Carbook.Application.Common.Persistence;
using Carbook.Persistence.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Carbook.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<ICarsRepository, CarsRepository>();

        //TODO configuration
        services.AddDbContext<CarsDbContext>(options =>
        {
            options.UseSqlite("Data Source=Cars.db");
        });
        
        return services;
    }
}