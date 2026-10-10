using DotnetBaseKit.Domain.Repositories;
using DotnetBaseKit.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetBaseKit.Infra.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IExampleWriteRepository, ExampleWriteRepository>();
        services.AddScoped<IExampleReadRepository, ExampleReadRepository>();
        
        return services;
    }
}