using DotnetBaseKit.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetBaseKit.Application.Extensions

{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IExampleServiceApplication, ExampleServiceApplication>();

            return services;
        }
    }
}