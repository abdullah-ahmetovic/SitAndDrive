using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Abstractions;

public interface IAppDbContext
{
    DbSet<Company> Companies { get; }
    DbSet<Branch> Branches { get; }
    DbSet<Person> People { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Customer> Customers { get; }

    DbSet<Manufacturer> Manufacturers { get; }
    DbSet<CarModel> CarModels { get; }
    DbSet<Car> Cars { get; }

    DbSet<Reservation> Reservations { get; }
    DbSet<ReservationExtension> ReservationExtensions { get; }
    DbSet<CarDamage> CarDamages { get; }

    DbSet<Invoice> Invoices { get; }
    //DbSet<InvoiceItem> InvoiceItems { get; }
    DbSet<Transaction> Transactions { get; }

    //DbSet<RefreshTokenEntity> RefreshTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}