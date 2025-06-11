using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantCare.Domain.Entities;

namespace PlantCare.Infra.Configurations;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(e => e.Id)
            .HasName("users_pkey");

        builder.ToTable("users");
        
        builder
            .HasMany(e => e.Plants)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

        builder.HasIndex(e => e.Email, "users_email_key")
            .IsUnique();

        builder.HasIndex(e => e.Username, "users_username_key")
            .IsUnique();

        builder
            .Property(e => e.Id)
            .HasColumnName("id");
        
        builder.Property(e => e.Active)
            .HasDefaultValue(true)
            .HasColumnName("active");
            
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnName("created_at");
            
        builder.Property(e => e.Email)
            .HasMaxLength(320)
            .HasColumnName("email");
            
        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .HasColumnName("name");
            
        builder.Property(e => e.PasswordHash)
            .HasMaxLength(255)
            .HasColumnName("password_hash");
            
        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnName("updated_at");
            
        builder.Property(e => e.Username)
            .HasMaxLength(50)
            .HasColumnName("username");
    }
}