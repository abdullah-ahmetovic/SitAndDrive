using Market.Domain.SitDrive.Entities;
using Market.Domain.SitDrive.Enums;
using Microsoft.EntityFrameworkCore;

namespace Market.Infrastructure.Database.Seeders;

public partial class StaticDataSeeder
{
    private static DateTime DateTime { get; set; } = new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local);

    public static void Seed(ModelBuilder modelBuilder)
    {
        SeedSitDrive(modelBuilder);
    }

    private static void SeedSitDrive(ModelBuilder modelBuilder)
    {
        const int companyId = 1001;
        const int firmId = companyId;

        const int branchId = 2001;

        // Manufacturer IDs
        const int mfrVw = 3001;
        const int mfrBmw = 3002;
        const int mfrMercedes = 3003;
        const int mfrAudi = 3004;
        const int mfrToyota = 3005;
        const int mfrHonda = 3006;

        // Model IDs
        const int mdlGolf7 = 4001;
        const int mdlPassat = 4002;
        const int mdl3Series = 4003;
        const int mdlCClass = 4004;
        const int mdlA4 = 4005;
        const int mdlCorolla = 4006;
        const int mdlCivic = 4007;
        const int mdlX5 = 4008;

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

        modelBuilder.Entity<Company>().HasData(company);
        modelBuilder.Entity<Branch>().HasData(branch);

        // Manufacturers
        modelBuilder.Entity<Manufacturer>().HasData(
            new Manufacturer { Id = mfrVw, FirmId = firmId, Name = "Volkswagen", CreatedAtUtc = DateTime, IsDeleted = false },
            new Manufacturer { Id = mfrBmw, FirmId = firmId, Name = "BMW", CreatedAtUtc = DateTime, IsDeleted = false },
            new Manufacturer { Id = mfrMercedes, FirmId = firmId, Name = "Mercedes-Benz", CreatedAtUtc = DateTime, IsDeleted = false },
            new Manufacturer { Id = mfrAudi, FirmId = firmId, Name = "Audi", CreatedAtUtc = DateTime, IsDeleted = false },
            new Manufacturer { Id = mfrToyota, FirmId = firmId, Name = "Toyota", CreatedAtUtc = DateTime, IsDeleted = false },
            new Manufacturer { Id = mfrHonda, FirmId = firmId, Name = "Honda", CreatedAtUtc = DateTime, IsDeleted = false }
        );

        // Car Models
        modelBuilder.Entity<CarModel>().HasData(
            new CarModel { Id = mdlGolf7, FirmId = firmId, ManufacturerId = mfrVw, Name = "Golf 7", CreatedAtUtc = DateTime, IsDeleted = false },
            new CarModel { Id = mdlPassat, FirmId = firmId, ManufacturerId = mfrVw, Name = "Passat B8", CreatedAtUtc = DateTime, IsDeleted = false },
            new CarModel { Id = mdl3Series, FirmId = firmId, ManufacturerId = mfrBmw, Name = "3 Series", CreatedAtUtc = DateTime, IsDeleted = false },
            new CarModel { Id = mdlCClass, FirmId = firmId, ManufacturerId = mfrMercedes, Name = "C-Class", CreatedAtUtc = DateTime, IsDeleted = false },
            new CarModel { Id = mdlA4, FirmId = firmId, ManufacturerId = mfrAudi, Name = "A4", CreatedAtUtc = DateTime, IsDeleted = false },
            new CarModel { Id = mdlCorolla, FirmId = firmId, ManufacturerId = mfrToyota, Name = "Corolla", CreatedAtUtc = DateTime, IsDeleted = false },
            new CarModel { Id = mdlCivic, FirmId = firmId, ManufacturerId = mfrHonda, Name = "Civic", CreatedAtUtc = DateTime, IsDeleted = false },
            new CarModel { Id = mdlX5, FirmId = firmId, ManufacturerId = mfrBmw, Name = "X5", CreatedAtUtc = DateTime, IsDeleted = false }
        );

        // Cars (8 total)
        modelBuilder.Entity<Car>().HasData(
            new Car
            {
                Id = 5001, FirmId = firmId, BranchId = branchId,
                ManufacturerId = mfrVw, CarModelId = mdlGolf7,
                LicensePlate = "E12-K-345", Vin = "WVWZZZ1KZFW000001",
                Color = "Black", Transmission = CarTransmission.Manual,
                Year = 2018, PowerKw = 81.0, FuelConsumption = 5.4,
                DailyPrice = 85.00m, Status = EntityStatus.Active,
                CreatedAtUtc = DateTime, IsDeleted = false
            },
            new Car
            {
                Id = 5002, FirmId = firmId, BranchId = branchId,
                ManufacturerId = mfrBmw, CarModelId = mdl3Series,
                LicensePlate = "A45-M-112", Vin = "WBA8E9C50GK000002",
                Color = "White", Transmission = CarTransmission.Automatic,
                Year = 2020, PowerKw = 135.0, FuelConsumption = 6.2,
                DailyPrice = 120.00m, Status = EntityStatus.Active,
                CreatedAtUtc = DateTime, IsDeleted = false
            },
            new Car
            {
                Id = 5003, FirmId = firmId, BranchId = branchId,
                ManufacturerId = mfrMercedes, CarModelId = mdlCClass,
                LicensePlate = "J22-A-890", Vin = "WDDWF4KB1FR000003",
                Color = "Silver", Transmission = CarTransmission.Automatic,
                Year = 2021, PowerKw = 150.0, FuelConsumption = 6.8,
                DailyPrice = 130.00m, Status = EntityStatus.Active,
                CreatedAtUtc = DateTime, IsDeleted = false
            },
            new Car
            {
                Id = 5004, FirmId = firmId, BranchId = branchId,
                ManufacturerId = mfrAudi, CarModelId = mdlA4,
                LicensePlate = "T33-J-567", Vin = "WAUZZZ8K9FA000004",
                Color = "Blue", Transmission = CarTransmission.Automatic,
                Year = 2019, PowerKw = 110.0, FuelConsumption = 5.9,
                DailyPrice = 105.00m, Status = EntityStatus.Active,
                CreatedAtUtc = DateTime, IsDeleted = false
            },
            new Car
            {
                Id = 5005, FirmId = firmId, BranchId = branchId,
                ManufacturerId = mfrToyota, CarModelId = mdlCorolla,
                LicensePlate = "K88-E-234", Vin = "JTDKN3DU5A0000005",
                Color = "Red", Transmission = CarTransmission.Manual,
                Year = 2022, PowerKw = 103.0, FuelConsumption = 4.8,
                DailyPrice = 75.00m, Status = EntityStatus.Active,
                CreatedAtUtc = DateTime, IsDeleted = false
            },
            new Car
            {
                Id = 5006, FirmId = firmId, BranchId = branchId,
                ManufacturerId = mfrHonda, CarModelId = mdlCivic,
                LicensePlate = "M15-T-678", Vin = "2HGFC2F59MH000006",
                Color = "Gray", Transmission = CarTransmission.Manual,
                Year = 2021, PowerKw = 95.0, FuelConsumption = 5.1,
                DailyPrice = 70.00m, Status = EntityStatus.Active,
                CreatedAtUtc = DateTime, IsDeleted = false
            },
            new Car
            {
                Id = 5007, FirmId = firmId, BranchId = branchId,
                ManufacturerId = mfrVw, CarModelId = mdlPassat,
                LicensePlate = "SA-O-1234", Vin = "WVWZZZ3CZWE000007",
                Color = "Black", Transmission = CarTransmission.Automatic,
                Year = 2023, PowerKw = 140.0, FuelConsumption = 5.7,
                DailyPrice = 110.00m, Status = EntityStatus.Active,
                CreatedAtUtc = DateTime, IsDeleted = false
            },
            new Car
            {
                Id = 5008, FirmId = firmId, BranchId = branchId,
                ManufacturerId = mfrBmw, CarModelId = mdlX5,
                LicensePlate = "SA-K-5678", Vin = "5UXCR6C05L9000008",
                Color = "White", Transmission = CarTransmission.Automatic,
                Year = 2022, PowerKw = 195.0, FuelConsumption = 8.5,
                DailyPrice = 150.00m, Status = EntityStatus.Active,
                CreatedAtUtc = DateTime, IsDeleted = false
            }
        );
    }
}
