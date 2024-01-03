namespace Carbook.API.Setup;

public static class OptionsRegistration
{
    public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddOptions<CorsOptions>().Bind(configuration.GetSection(CorsOptions.Key));
        
        return services;
    }
}