using Infrastructure.Interfaces;
using Infrastructure.Providers;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IDatetimeProvider, DatetimeProvider>();
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}