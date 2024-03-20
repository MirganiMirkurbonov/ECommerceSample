using Database.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Database.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<EntityContext>();
        return services;
    }
}