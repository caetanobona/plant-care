using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantCare.Domain.Entities;

namespace PlantCare.Infra.Configurations;

public class PlantsConfiguration : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.HasKey(e => e.Id).HasName("plants_pkey");

        builder.ToTable("plants");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Active)
            .HasDefaultValue(true)
            .HasColumnName("active");
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnName("created_at");
        builder.Property(e => e.ImageUrl)
            .HasMaxLength(255)
            .HasColumnName("image_url");
        builder.Property(e => e.LastWatered).HasColumnName("last_watered");
        builder.Property(e => e.LightRequirements)
            .HasMaxLength(50)
            .HasColumnName("light_requirements");
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        builder.Property(e => e.Species)
            .HasMaxLength(120)
            .HasColumnName("species");
        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnName("updated_at");
        builder.Property(e => e.UserId).HasColumnName("user_id");
        builder.Property(e => e.WateringInterval).HasColumnName("watering_interval");

        builder.HasOne(d => d.User).WithMany(p => p.Plants)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("plants_user_id_fkey");
    }
}