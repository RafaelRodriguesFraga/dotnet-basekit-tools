using Microsoft.OpenApi.Models;

namespace DotnetBaseKit.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "DotnetBaseKit", Version = "v1" });

        });

        return services;
    }
}