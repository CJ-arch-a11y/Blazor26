using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blazor26.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "MonthName", "ProductID", "SalesAmount" },
                values: new object[,]
                {
                    { 1, "Jan", 1, 53m },
                    { 2, "Feb", 1, 29m },
                    { 3, "Mar", 1, 92m },
                    { 4, "Apr", 1, 79m },
                    { 5, "May", 1, 63m },
                    { 6, "Jun", 1, 32m },
                    { 7, "Jul", 1, 5m },
                    { 8, "Aug", 1, 89m },
                    { 9, "Sep", 1, 29m },
                    { 10, "Oct", 1, 41m },
                    { 11, "Nov", 1, 84m },
                    { 12, "Dec", 1, 46m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
