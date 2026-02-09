using Market.Application.Abstractions;
using Market.Domain.SitDrive.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Database;

public partial class DatabaseContext : DbContext, IAppDbContext
{
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Person> People => Set<Person>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
    public DbSet<CarModel> CarModels => Set<CarModel>();
    public DbSet<Car> Cars => Set<Car>();

    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<ReservationExtension> ReservationExtensions => Set<ReservationExtension>();
    public DbSet<CarDamage> CarDamages => Set<CarDamage>();

    public DbSet<Invoice> Invoices => Set<Invoice>();
    //public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    //public DbSet<RefreshTokenEntity> RefreshTokens => Set<RefreshTokenEntity>();

    private readonly TimeProvider _clock;
    public DatabaseContext(DbContextOptions<DatabaseContext> options, TimeProvider clock) : base(options)
    {
        _clock = clock;
    }
}