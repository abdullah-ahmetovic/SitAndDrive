using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.SitDrive;

public sealed class ReservationExtensionConfiguration : IEntityTypeConfiguration<ReservationExtension>
{
    public void Configure(EntityTypeBuilder<ReservationExtension> builder)
    {
        builder.ToTable("ReservationExtensions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirmId).IsRequired();

        builder.HasOne(x => x.Reservation)
            .WithMany(x => x.Extensions)
            .HasForeignKey(x => x.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApprovedByEmployee)
            .WithMany(x => x.ApprovedExtensions)
            .HasForeignKey(x => x.ApprovedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}