namespace Domain.Options;

public record DatabaseOptions(
    string ConnectionString)
{
    public DatabaseOptions() : this(String.Empty)
    {
    }
};