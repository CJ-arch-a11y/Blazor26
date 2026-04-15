using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blazor26.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class salesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MonthName = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Desktops" },
                    { 2, "Printers" },
                    { 3, "Display Tables" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Image", "Name", "Price", "description" },
                values: new object[,]
                {
                    { 1, 1, null, "HP PRo", 892.99f, "Big desktop PC" },
                    { 2, 1, null, "Dell X100", 140.99f, "Not a laptop" },
                    { 3, 2, null, "HP 450x", 1200.99f, "bad colour printer" },
                    { 4, 2, null, "HP Meezie", 12500.99f, "Good colour printer" },
                    { 5, 3, null, "Gala Table", 12123.99f, "Very Big Table" },
                    { 6, 3, null, "DreamTop", 900.99f, "Big Table" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "MonthName", "ProductID", "SalesAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1200m },
                    { 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1300m },
                    { 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1400m },
                    { 4, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1500m },
                    { 5, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1600m },
                    { 6, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1700m },
                    { 7, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1800m },
                    { 8, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1900m },
                    { 9, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2000m },
                    { 10, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2100m },
                    { 11, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2200m },
                    { 12, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2300m },
                    { 13, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1400m },
                    { 14, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1500m },
                    { 15, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1600m },
                    { 16, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1700m },
                    { 17, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1800m },
                    { 18, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1900m },
                    { 19, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2000m },
                    { 20, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2100m },
                    { 21, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2200m },
                    { 22, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2300m },
                    { 23, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2400m },
                    { 24, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2500m },
                    { 25, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1600m },
                    { 26, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1700m },
                    { 27, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1800m },
                    { 28, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1900m },
                    { 29, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2000m },
                    { 30, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2100m },
                    { 31, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2200m },
                    { 32, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2300m },
                    { 33, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2400m },
                    { 34, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2500m },
                    { 35, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2600m },
                    { 36, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2700m },
                    { 37, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1800m },
                    { 38, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1900m },
                    { 39, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2000m },
                    { 40, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2100m },
                    { 41, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2200m },
                    { 42, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2300m },
                    { 43, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2400m },
                    { 44, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2500m },
                    { 45, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2600m },
                    { 46, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2700m },
                    { 47, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2800m },
                    { 48, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2900m },
                    { 49, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2000m },
                    { 50, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2100m },
                    { 51, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2200m },
                    { 52, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2300m },
                    { 53, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2400m },
                    { 54, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2500m },
                    { 55, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2600m },
                    { 56, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2700m },
                    { 57, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2800m },
                    { 58, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2900m },
                    { 59, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3000m },
                    { 60, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3100m },
                    { 61, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2200m },
                    { 62, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2300m },
                    { 63, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2400m },
                    { 64, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2500m },
                    { 65, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2600m },
                    { 66, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2700m },
                    { 67, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2800m },
                    { 68, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2900m },
                    { 69, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3000m },
                    { 70, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3100m },
                    { 71, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3200m },
                    { 72, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3300m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductID",
                table: "Sales",
                column: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
