using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Context.Tables;

[Table("user_file")]
public class UserFile : Entity
{
    [Column("name")]
    public string Name { get; set; } = null!;
    [Column("keyword")]
    public string? Keyword { get; set; }
    [Column("type")]
    public string Type { get; set; } = null!;
    [Column("path")]
    public string Path { get; set; } = null!;
    [Column("size")]
    public long Size { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    [ForeignKey("user")]
    public virtual User User { get; set; }
}