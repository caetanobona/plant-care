using Microsoft.EntityFrameworkCore;
using PlantCare.Application.Context;
using PlantCare.Domain.Entities;

namespace PlantCare.Infra.Data;

public class PlantCareDbContext : DbContext, IPlantCareDbContext
{
    public PlantCareDbContext(DbContextOptions<PlantCareDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Plant> Plants { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            
            entity.Property(e => e.Email)
                .HasMaxLength(320)
                .HasColumnName("email");
            
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updated_at");
            
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            
            entity.HasQueryFilter(e => e.Active);
        });
        
        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("plants_pkey");

            entity.ToTable("plants");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.LastWatered).HasColumnName("last_watered");
            entity.Property(e => e.LightRequirements)
                .HasMaxLength(50)
                .HasColumnName("light_requirements");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Species)
                .HasMaxLength(120)
                .HasColumnName("species");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WateringInterval).HasColumnName("watering_interval");

            entity.HasOne(d => d.User).WithMany(p => p.Plants)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("plants_user_id_fkey");
            
            entity.HasQueryFilter(e => e.Active);
        });
        
        base.OnModelCreating(modelBuilder);
    }
}