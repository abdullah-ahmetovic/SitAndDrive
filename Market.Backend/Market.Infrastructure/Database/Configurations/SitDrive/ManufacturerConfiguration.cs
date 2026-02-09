using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.SitDrive;

public sealed class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.ToTable("Manufacturers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirmId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();

        builder.HasIndex(x => new { x.FirmId, x.Name }).IsUnique();

        builder.HasMany(x => x.Models)
            .WithOne(x => x.Manufacturer)
            .HasForeignKey(x => x.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}