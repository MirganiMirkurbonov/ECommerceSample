using Amazon.S3;
using Infrastructure.AWSServices.S3;
using Infrastructure.Interfaces;
using Infrastructure.Providers;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddScoped<IDatetimeProvider, DatetimeProvider>()
            .AddScoped<ITokenService, TokenService>()
            .AddScoped<IAmazonS3, AmazonS3Client>()
            .AddScoped<IAwsS3Manager, AwsS3Manager>();

        return services;
    }
}