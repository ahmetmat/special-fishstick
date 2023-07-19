using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
  
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Users> users { get; set; }
}

public class Users
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public int yas { get; set; }
    public DateTime created_at { get; set; } = DateTime.Now;
    public required string roles { get; set; }
}
