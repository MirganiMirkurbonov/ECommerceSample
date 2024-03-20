using Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public partial class EntityContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserFile> UserFiles { get; set; }
}