using Healix_WebApp.Models;
using Microsoft.EntityFrameworkCore;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(u => u.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(u => u.LastName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(u => u.MobileCountryCode)
                .HasMaxLength(3);

            entity.Property(u => u.MobileNumber)
                .HasMaxLength(20);

            entity.Property(u => u.Status)
                .IsRequired()
                .HasConversion<string>();

        });

        base.OnModelCreating(modelBuilder);
    }
}
