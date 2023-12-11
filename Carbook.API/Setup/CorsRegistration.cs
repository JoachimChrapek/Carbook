using Microsoft.Extensions.Options;

namespace Carbook.API.Setup;

public static class CorsRegistration
{
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        CorsOptions corsOptions = services.BuildServiceProvider().GetRequiredService<IOptions<CorsOptions>>().Value;

        //TODO invert if and throw(?), handle wrong config data
        if (corsOptions.AllowedOrigins is not null && corsOptions.AllowedOrigins.Length != 0)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(corsOptions.AllowedOrigins)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        return services;
    }
}