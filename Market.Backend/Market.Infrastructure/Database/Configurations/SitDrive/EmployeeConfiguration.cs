using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.SitDrive;

public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirmId).IsRequired();
        builder.Property(x => x.NationalIdNumber).HasMaxLength(30).IsRequired();

        builder.HasIndex(x => new { x.FirmId, x.PersonId }).IsUnique();
        builder.HasIndex(x => new { x.FirmId, x.NationalIdNumber }).IsUnique();

        builder.HasOne(x => x.Person)
            .WithOne(x => x.Employee)
            .HasForeignKey<Employee>(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Branch)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ApprovedReservations)
            .WithOne(x => x.ApprovedByEmployee)
            .HasForeignKey(x => x.ApprovedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ApprovedExtensions)
            .WithOne(x => x.ApprovedByEmployee)
            .HasForeignKey(x => x.ApprovedByEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}