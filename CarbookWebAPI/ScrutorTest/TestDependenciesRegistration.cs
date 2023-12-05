using Scrutor;

namespace CarbookWebAPI.ScrutorTest;

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

        return services;
    }
}