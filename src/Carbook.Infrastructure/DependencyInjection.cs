using Carbook.Domain.Authentication;
using Carbook.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Carbook.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        
        return services;
    }
}