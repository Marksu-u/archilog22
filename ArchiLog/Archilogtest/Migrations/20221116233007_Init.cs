using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Archilogtest.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "Slogan" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1896, 1, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "Peugeot", "Lions de notre temps" },
                    { 2, true, new DateTime(1919, 6, 4, 12, 0, 0, 0, DateTimeKind.Utc), null, "Citroën", "Inspiré par vous" },
                    { 3, true, new DateTime(1898, 12, 24, 12, 0, 0, 0, DateTimeKind.Utc), null, "Renault", "Renault, des voitures à vivre" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "ID", "Active", "BrandID", "CreatedAt", "DeletedAt", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2019, 10, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "208 Electrique", 25000 },
                    { 2, true, 1, new DateTime(2013, 9, 12, 12, 0, 0, 0, DateTimeKind.Utc), null, "308 Hybride", 15000 },
                    { 3, true, 1, new DateTime(2020, 2, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "508 PSE", 30000 },
                    { 4, true, 3, new DateTime(2022, 10, 13, 12, 0, 0, 0, DateTimeKind.Utc), null, "C4 Electrique", 35000 },
                    { 5, true, 3, new DateTime(2019, 4, 2, 12, 0, 0, 0, DateTimeKind.Utc), null, "Clio 5", 45000 },
                    { 6, true, 2, new DateTime(2020, 12, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "C4", 40000 },
                    { 7, true, 2, new DateTime(2021, 2, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "SpaceTourer XS", 25000 },
                    { 8, true, 1, new DateTime(2019, 10, 14, 12, 0, 0, 0, DateTimeKind.Utc), null, "3008", 10000 },
                    { 9, true, 2, new DateTime(2020, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "GS", 25000 },
                    { 10, true, 1, new DateTime(2021, 5, 1, 12, 0, 0, 0, DateTimeKind.Utc), null, "DS 9", 50000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandID",
                table: "Cars",
                column: "BrandID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
