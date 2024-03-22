using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Context.Tables;

[Table("user")]
public class User : Entity
{
    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("last_name")]
    public string? LastName { get; set; }

    [Column("username")]
    public string Username { get; set; }
    
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }
    
    [Column("password_hash")]
    public string PasswordHash { get; set; }
}