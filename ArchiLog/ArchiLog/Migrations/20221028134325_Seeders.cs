using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchiLog.Migrations
{
    public partial class Seeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "Slogan" },
                values: new object[] { 1, true, new DateTime(2022, 10, 28, 13, 43, 25, 265, DateTimeKind.Utc).AddTicks(5366), null, "Peugeot", "Nos voitures pas chères" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "Slogan" },
                values: new object[] { 2, true, new DateTime(2022, 10, 28, 13, 43, 25, 265, DateTimeKind.Utc).AddTicks(5369), null, "Citroën", "Nos voitures très chères" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "ID", "Active", "BrandID", "CreatedAt", "DeletedAt", "Name", "Price" },
                values: new object[] { 1, true, 1, new DateTime(2022, 10, 28, 13, 43, 25, 265, DateTimeKind.Utc).AddTicks(5513), null, "Pas cher V1", 0 });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "ID", "Active", "BrandID", "CreatedAt", "DeletedAt", "Name", "Price" },
                values: new object[] { 2, true, 1, new DateTime(2022, 10, 28, 13, 43, 25, 265, DateTimeKind.Utc).AddTicks(5515), null, "Pas cher V2", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
