using System.Reflection;
using Domain.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Database.Context;

public partial class EntityContext : DbContext
{
    private readonly string _connectionString;
    public EntityContext(IOptions<DatabaseOptions> options)
    {
        _connectionString = options.Value.ConnectionString;
        Console.WriteLine(_connectionString);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_connectionString,
            builder => { builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(2), null); });
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}