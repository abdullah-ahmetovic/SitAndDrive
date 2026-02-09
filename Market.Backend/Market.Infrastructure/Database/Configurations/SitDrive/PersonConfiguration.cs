using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Market.Infrastructure.Database.Configurations.SitDrive;

public sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirmId).IsRequired();

        builder.Property(x => x.FirstName).HasMaxLength(80).IsRequired();
        builder.Property(x => x.LastName).HasMaxLength(80).IsRequired();

        builder.Property(x => x.Email).HasMaxLength(150).IsRequired();
        builder.Property(x => x.PhoneNumber).HasMaxLength(30).IsRequired();

        builder.Property(x => x.PasswordHash).HasMaxLength(300).IsRequired();

        builder.HasIndex(x => new { x.FirmId, x.Email }).IsUnique();

        builder.HasOne(x => x.Customer)
            .WithOne(x => x.Person)
            .HasForeignKey<Customer>(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Employee)
            .WithOne(x => x.Person)
            .HasForeignKey<Employee>(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}