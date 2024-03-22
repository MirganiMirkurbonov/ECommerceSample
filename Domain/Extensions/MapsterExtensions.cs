using Mapster;

namespace Domain.Extensions;

public static class MapsterExtensions
{
    public static T MapTo<T>(this object source) where T : class =>
        source.Adapt<T>();
    
    public static TypeAdapterConfig CreateGlobalConfig()
    {
        var config = TypeAdapterConfig.GlobalSettings;
        Configure(config);

        return config;
    }
    private static void Configure(TypeAdapterConfig config)
    {
        config.RequireExplicitMapping = true;

        _ = config.Default
            .IgnoreNonMapped(true)
            .NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);
    }
}