using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.SitDrive;

public sealed class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
{
    public void Configure(EntityTypeBuilder<CarModel> builder)
    {
        builder.ToTable("CarModels");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirmId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();

        builder.HasIndex(x => new { x.FirmId, x.ManufacturerId, x.Name }).IsUnique();

        builder.HasOne(x => x.Manufacturer)
            .WithMany(x => x.Models)
            .HasForeignKey(x => x.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Cars)
            .WithOne(x => x.CarModel)
            .HasForeignKey(x => x.CarModelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}