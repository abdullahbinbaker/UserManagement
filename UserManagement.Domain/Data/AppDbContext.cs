using Microsoft.EntityFrameworkCore;

namespace UserManagement.Domain.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
