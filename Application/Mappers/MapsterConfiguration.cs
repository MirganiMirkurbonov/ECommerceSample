using System.Reflection;
using Mapster;

namespace Application.Mappers;

public static class MapsterConfiguration
{
    public static void Scan(TypeAdapterConfig config)
    {
        config.Scan(Assembly.GetExecutingAssembly());
    }
}