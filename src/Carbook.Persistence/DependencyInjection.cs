using Carbook.Application.Common.Persistence;
using Carbook.Persistence.Cars;
using Carbook.Persistence.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Carbook.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<ICarsRepository, CarsRepository>();
        services.AddScoped<IUserRepository, UsersRepository>();

        //TODO configuration
        services.AddDbContext<CarbookDbContext>(options =>
        {
            options.UseSqlite("Data Source=Cars.db");
        });
        
        return services;
    }
}