using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CreatedAtUtc", "FirmId", "IsDeleted", "ManufacturerId", "ModifiedAtUtc", "Name" },
                values: new object[] { 4002, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, 3001, null, "Passat B8" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedAtUtc", "FirmId", "IsDeleted", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 3002, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, null, "BMW" },
                    { 3003, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, null, "Mercedes-Benz" },
                    { 3004, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, null, "Audi" },
                    { 3005, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, null, "Toyota" },
                    { 3006, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, null, "Honda" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CreatedAtUtc", "FirmId", "IsDeleted", "ManufacturerId", "ModifiedAtUtc", "Name" },
                values: new object[,]
                {
                    { 4003, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, 3002, null, "3 Series" },
                    { 4004, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, 3003, null, "C-Class" },
                    { 4005, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, 3004, null, "A4" },
                    { 4006, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, 3005, null, "Corolla" },
                    { 4007, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, 3006, null, "Civic" },
                    { 4008, new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 1001, false, 3002, null, "X5" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BranchId", "CarModelId", "Color", "CreatedAtUtc", "DailyPrice", "FirmId", "FuelConsumption", "IsDeleted", "LicensePlate", "ManufacturerId", "ModifiedAtUtc", "PowerKw", "Status", "Transmission", "Vin", "Year" },
                values: new object[,]
                {
                    { 5007, 2001, 4002, "Black", new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 110.00m, 1001, 5.7000000000000002, false, "SA-O-1234", 3001, null, 140.0, 0, 1, "WVWZZZ3CZWE000007", 2023 },
                    { 5002, 2001, 4003, "White", new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 120.00m, 1001, 6.2000000000000002, false, "A45-M-112", 3002, null, 135.0, 0, 1, "WBA8E9C50GK000002", 2020 },
                    { 5003, 2001, 4004, "Silver", new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 130.00m, 1001, 6.7999999999999998, false, "J22-A-890", 3003, null, 150.0, 0, 1, "WDDWF4KB1FR000003", 2021 },
                    { 5004, 2001, 4005, "Blue", new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 105.00m, 1001, 5.9000000000000004, false, "T33-J-567", 3004, null, 110.0, 0, 1, "WAUZZZ8K9FA000004", 2019 },
                    { 5005, 2001, 4006, "Red", new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 75.00m, 1001, 4.7999999999999998, false, "K88-E-234", 3005, null, 103.0, 0, 0, "JTDKN3DU5A0000005", 2022 },
                    { 5006, 2001, 4007, "Gray", new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 70.00m, 1001, 5.0999999999999996, false, "M15-T-678", 3006, null, 95.0, 0, 0, "2HGFC2F59MH000006", 2021 },
                    { 5008, 2001, 4008, "White", new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local), 150.00m, 1001, 8.5, false, "SA-K-5678", 3002, null, 195.0, 0, 1, "5UXCR6C05L9000008", 2022 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5002);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5003);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5004);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5005);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5006);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5007);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5008);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4002);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4003);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4004);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4005);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4006);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4007);

            migrationBuilder.DeleteData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4008);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3002);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3004);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3005);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3006);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Manufacturers_ManufacturerId",
                table: "Cars",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
