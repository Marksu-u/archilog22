using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchiLog.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "Slogan" },
                values: new object[] { 1, true, new DateTime(1896, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "Peugeot", "Lions de notre temps" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "Slogan" },
                values: new object[] { 2, true, new DateTime(1919, 6, 4, 12, 0, 0, 0, DateTimeKind.Utc), null, "Citroën", "Inspiré par vous" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "Slogan" },
                values: new object[] { 3, true, new DateTime(1898, 12, 24, 12, 0, 0, 0, DateTimeKind.Utc), null, "Renault", "Renault, des voitures à vivre" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "ID", "Active", "BrandID", "CreatedAt", "DeletedAt", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2019, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "208 Electrique", 0 },
                    { 2, true, 1, new DateTime(2013, 9, 12, 12, 0, 0, 0, DateTimeKind.Utc), null, "308 Hybride", 0 },
                    { 3, true, 1, new DateTime(2020, 2, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "508 PSE", 0 },
                    { 4, true, 3, new DateTime(2022, 10, 13, 12, 0, 0, 0, DateTimeKind.Utc), null, "C4 Electrique", 0 },
                    { 5, true, 3, new DateTime(2019, 4, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, "Clio 5", 0 },
                    { 6, true, 2, new DateTime(2020, 12, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "C4", 0 },
                    { 7, true, 2, new DateTime(2021, 2, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "SpaceTourer XS", 0 },
                    { 8, true, 1, new DateTime(2019, 10, 14, 12, 0, 0, 0, DateTimeKind.Utc), null, "3008", 0 },
                    { 9, true, 2, new DateTime(2020, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "GS", 0 },
                    { 10, true, 1, new DateTime(2021, 5, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "DS 9", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
