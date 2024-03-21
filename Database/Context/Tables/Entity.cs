using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Context.Tables;

public abstract class Entity
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}