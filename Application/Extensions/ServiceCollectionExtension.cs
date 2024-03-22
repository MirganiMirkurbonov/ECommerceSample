using Application.Interfaces;
using Application.Mappers;
using Application.Repositories;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services, TypeAdapterConfig config)
    {
        MapsterConfiguration.Scan(config);
        
        services
            .AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}