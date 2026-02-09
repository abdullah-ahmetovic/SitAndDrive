using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.SitDrive;

public sealed class CarDamageConfiguration : IEntityTypeConfiguration<CarDamage>
{
    public void Configure(EntityTypeBuilder<CarDamage> builder)
    {
        builder.ToTable("CarDamages");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirmId).IsRequired();

        builder.Property(x => x.Description).HasMaxLength(1000).IsRequired();

        builder.HasOne(x => x.Car)
            .WithMany(x => x.Damages)
            .HasForeignKey(x => x.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Reservation)
            .WithMany(x => x.Damages)
            .HasForeignKey(x => x.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}