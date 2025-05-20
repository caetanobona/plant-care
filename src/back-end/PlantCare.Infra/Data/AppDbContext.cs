using Microsoft.EntityFrameworkCore;
using PlantCare.Domain.Entities;

namespace PlantCare.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            
            entity.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(320);
            
            entity.HasIndex(e => e.Email)
                .IsUnique();
            
            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.PasswordHash)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Active)
                .HasColumnName("is_active")
                .HasColumnType("tinyint(1)")
                .HasDefaultValue(true)
                .IsRequired();

        });
        
        
        base.OnModelCreating(modelBuilder);
    }
}