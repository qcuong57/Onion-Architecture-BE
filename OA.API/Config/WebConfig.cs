namespace Onion_Architecture.Config;

using Microsoft.Extensions.DependencyInjection;

public static class WebConfig
{
    public static void Configure(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            options.AddPolicy("AllowSpecificMethods", builder =>
            {
                builder.AllowAnyOrigin()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowAnyHeader();
            });
        });
    }
}