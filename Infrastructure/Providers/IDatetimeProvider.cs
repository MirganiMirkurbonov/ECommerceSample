namespace Infrastructure.Providers;

public interface IDatetimeProvider
{
    public DateTime UtcNow();
}