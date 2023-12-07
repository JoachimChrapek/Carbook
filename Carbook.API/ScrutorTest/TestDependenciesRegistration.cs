using Carbook.API.Cars;
using Scrutor;

namespace Carbook.API.ScrutorTest;

public static class TestDependenciesRegistration
{
    public static IServiceCollection AddTestServices(this IServiceCollection services)
    {
        services.Scan(selector =>
        {
            selector.FromType<IdProvider>()
                .AsSelfWithInterfaces()
                .WithSingletonLifetime();
        });

        services.Scan(selector =>
        {
            selector.FromAssemblyOf<Program>()
                .AddClasses(f => f.AssignableTo<ICarService>())
                .As(s => s.GetInterfaces().Where(i => i != typeof(ICarService)))
                .WithScopedLifetime();
        });

        return services;
    }
}