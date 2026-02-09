using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.SitDrive;

public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirmId).IsRequired();

        builder.Property(x => x.LicensePlate).HasMaxLength(20).IsRequired();
        builder.Property(x => x.Vin).HasMaxLength(40).IsRequired();
        builder.Property(x => x.Color).HasMaxLength(50).IsRequired();

        builder.Property(x => x.DailyPrice).HasPrecision(18, 2);

        builder.HasIndex(x => new { x.FirmId, x.LicensePlate }).IsUnique();
        builder.HasIndex(x => new { x.FirmId, x.Vin }).IsUnique();

        builder.HasOne(x => x.Branch)
            .WithMany(x => x.Cars)
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CarModel)
            .WithMany(x => x.Cars)
            .HasForeignKey(x => x.CarModelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Manufacturer)
            .WithMany()
            .HasForeignKey(x => x.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Reservations)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Damages)
            .WithOne(x => x.Car)
            .HasForeignKey(x => x.CarId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}