using Domain.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<JwtOptions>()
            .Bind(configuration.GetSection(nameof(JwtOptions)));
        
        services.AddOptions<AwsS3Options>()
            .Bind(configuration.GetSection(nameof(AwsS3Options)));
        return services;
    }
}