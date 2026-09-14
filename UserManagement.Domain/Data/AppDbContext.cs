using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id)
                       .ValueGeneratedOnAdd();
            entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
            entity.Property(u => u.Email).IsRequired().HasMaxLength(256);
            entity.Property(u => u.MobileNumber).IsRequired().HasMaxLength(15);
            entity.HasIndex(u => u.SocialIdFK).IsUnique().IsClustered(false);
            entity.HasIndex(u => u.Email).IsUnique().IsClustered(false);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.HasKey(a => a.Id);
            entity.Property(a => a.StreetName).IsRequired().HasMaxLength(256);
            entity.Property(a => a.City).IsRequired().HasMaxLength(100);
            entity.Property(a => a.HouseNo).IsRequired().HasMaxLength(20);
            entity.Property(a => a.Country).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Id)
           .ValueGeneratedOnAdd();
            entity.HasOne(a => a.User)
                  .WithMany(u => u.Addresses)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasIndex(u => u.UserId).IsClustered(false);
        });

    }
}
