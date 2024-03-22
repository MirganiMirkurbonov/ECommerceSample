using System.Reflection;
using Database.Context.Tables;
using Database.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Database.Context;

public partial class EntityContext(IOptions<DatabaseOptions> _options) : DbContext
{
    private readonly string _connectionString = _options.Value.ConnectionString;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_connectionString,
            builder => { builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(2), null); });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entity in ChangeTracker.Entries<Entity>())
        {
            switch (entity.State)
            {
                case EntityState.Modified:
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entity.Entity.CreatedAt = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

}