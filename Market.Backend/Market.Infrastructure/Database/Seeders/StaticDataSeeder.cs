using Market.Domain.SitDrive.Entities;
using Market.Domain.SitDrive.Enums;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Database.Seeders;

public partial class StaticDataSeeder
{
    private static DateTime DateTime { get; set; } = new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local);

    public static void Seed(ModelBuilder modelBuilder)
    {
        // Static data is added in the migration
        // if it does not exist in the DB at the time of creating the migration
        // example of static data: roles
        //SeedProductCategories(modelBuilder);
        SeedSitDrive(modelBuilder);
    }

    /*private static void SeedProductCategories(ModelBuilder modelBuilder)
    {
        // todo: user roles

        //modelBuilder.Entity<UserRoles>().HasData(new List<UserRoleEntity>
        //{
        //    new UserRoleEntity{
        //        Id = 1,
        //        Name = "Admin",
        //        CreatedAt = dateTime,
        //        ModifiedAt = null,
        //    },
        //    new UserRoleEntity{
        //        Id = 2,
        //        Name = "Employee",
        //        CreatedAt = dateTime,
        //        ModifiedAt = null,
        //    },
        //});
    }*/

    private static void SeedSitDrive(ModelBuilder modelBuilder)
    {
        const int companyId = 1001;
        const int firmId = companyId;

        const int branchId = 2001;
        const int manufacturerId = 3001;
        const int modelId = 4001;
        const int carId = 5001;

        var company = new Company
        {
            Id = companyId,
            FirmId = firmId,
            Name = "Sit & Drive d.o.o.",
            Address = "Zmaja od Bosne 12, Sarajevo",
            Email = "info@sitdrive.ba",
            PhoneNumber = "+38761111222",
            Status = EntityStatus.Active,
            CreatedAtUtc = DateTime,
            ModifiedAtUtc = null,
            IsDeleted = false
        };

        var branch = new Branch
        {
            Id = branchId,
            FirmId = firmId,
            CompanyId = companyId,
            Name = "Sarajevo - Main Branch",
            Address = "Bulevar Meše Selimovića 20, Sarajevo",
            Email = "sarajevo@sitdrive.ba",
            PhoneNumber = "+38761111333",
            Status = EntityStatus.Active,
            CreatedAtUtc = DateTime,
            ModifiedAtUtc = null,
            IsDeleted = false
        };

        var manufacturer = new Manufacturer
        {
            Id = manufacturerId,
            FirmId = firmId,
            Name = "Volkswagen",
            CreatedAtUtc = DateTime,
            ModifiedAtUtc = null,
            IsDeleted = false
        };

        var carModel = new CarModel
        {
            Id = modelId,
            FirmId = firmId,
            ManufacturerId = manufacturerId,
            Name = "Golf 7",
            CreatedAtUtc = DateTime,
            ModifiedAtUtc = null,
            IsDeleted = false
        };

        var car = new Car
        {
            Id = carId,
            FirmId = firmId,
            BranchId = branchId,
            ManufacturerId = manufacturerId,
            CarModelId = modelId,
            LicensePlate = "E12-K-345",
            Vin = "WVWZZZ1KZFW000001",
            Color = "Black",
            Transmission = CarTransmission.Manual,
            Year = 2018,
            PowerKw = 81.0,
            FuelConsumption = 5.4,
            DailyPrice = 85.00m,
            Status = EntityStatus.Active,
            CreatedAtUtc = DateTime,
            ModifiedAtUtc = null,
            IsDeleted = false
        };

        modelBuilder.Entity<Company>().HasData(company);
        modelBuilder.Entity<Branch>().HasData(branch);
        modelBuilder.Entity<Manufacturer>().HasData(manufacturer);
        modelBuilder.Entity<CarModel>().HasData(carModel);
        modelBuilder.Entity<Car>().HasData(car);
    }
}