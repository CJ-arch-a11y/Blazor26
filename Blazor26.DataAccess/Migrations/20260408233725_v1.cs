using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blazor26.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { 1, "Mystery" },
                    { 2, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Image", "Name", "Price", "description" },
                values: new object[,]
                {
                    { 1, 1, "\\Images\\Products\\Book2.webp", "Hamnet", 10f, "Hamnet tells the story of a boy whose life has been all but forgotten, but whose name was given to one of the most celebrated plays ever written. It is also the story of a marriage, of a couple brought together by love and curiosity, and pulled apart by grief. Inspired by the son Shakespeare lost, Maggie O’Farrell’s breathtaking novel is a luminous portrait of a family and a tender exploration of how art can emerge from sorrow." },
                    { 2, 2, "\\Images\\Products\\Book1.jpg", "In Glass Houses", 12f, "When everyone is looking in, a killer can only hide in plain sight Eddie has always known that the wrong man was made the scapegoat for Juliet's murder. So when a new luxury sky-rise is opened by Juliet's father, just metres from where her body was discovered two decades before, Eddie can't resist finding her way in, back into a world where dangerous people operate in the shadows, and anyone might kill to keep a secret safe." }
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
