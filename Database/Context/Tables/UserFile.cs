using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Context.Tables;

[Table("user_file")]
public class UserFile : Entity
{
    [Column("name")]
    public string Name { get; set; }
    
    [Column("path")]
    public string? Path { get; set; }

    [Column("extension")]
    public string? Extension { get; set; }
    
    [Column("size")]
    public long Size { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
}