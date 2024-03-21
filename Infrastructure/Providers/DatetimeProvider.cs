using Infrastructure.Interfaces;

namespace Infrastructure.Providers;

internal class DatetimeProvider : IDatetimeProvider
{
    public DateTime UtcNow() => DateTime.UtcNow;
}