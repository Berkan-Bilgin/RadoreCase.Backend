using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductService.Api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoverImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating_Stars = table.Column<double>(type: "float", nullable: false),
                    Rating_Reviews = table.Column<int>(type: "int", nullable: false),
                    Rating_Min = table.Column<double>(type: "float", nullable: false),
                    Rating_Max = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorOption_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLabel",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLabel", x => new { x.ProductId, x.LabelId });
                    table.ForeignKey(
                        name: "FK_ProductLabel_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLabel_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Technology" },
                    { 2, "Books" },
                    { 3, "Fashion" },
                    { 4, "Health" },
                    { 5, "Sports" }
                });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Sale" },
                    { 3, "Best Seller" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "HoverImg", "Img", "Price", "Title", "Rating_Max", "Rating_Min", "Rating_Reviews", "Rating_Stars" },
                values: new object[,]
                {
                    { 1, 1, "This is Product 1", "hoverImg1.jpg", "img1.jpg", 149.99m, "Product 1", 5.0, 0.0, 20, 4.5 },
                    { 2, 2, "This is Product 2", "hoverImg2.jpg", "img2.jpg", 129.99m, "Product 2", 5.0, 0.0, 15, 4.0 },
                    { 3, 3, "This is Product 3", "hoverImg3.jpg", "img3.jpg", 249.99m, "Product 3", 5.0, 0.0, 30, 4.7999999999999998 },
                    { 4, 4, "This is Product 4", "hoverImg4.jpg", "img4.jpg", 349.99m, "Product 4", 5.0, 0.0, 40, 3.5 },
                    { 5, 5, "This is Product 5", "hoverImg5.jpg", "img5.jpg", 149.99m, "Product 5", 5.0, 0.0, 10, 4.2000000000000002 }
                });

            migrationBuilder.InsertData(
                table: "ColorOption",
                columns: new[] { "Id", "Color", "Img", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, "Red", "red1.jpg", 1, 5 },
                    { 2, "Blue", "blue1.jpg", 1, 10 },
                    { 3, "Green", "green2.jpg", 2, 8 },
                    { 4, "Yellow", "yellow3.jpg", 3, 15 },
                    { 5, "Black", "black4.jpg", 4, 7 },
                    { 6, "White", "white5.jpg", 5, 12 }
                });

            migrationBuilder.InsertData(
                table: "ProductLabel",
                columns: new[] { "LabelId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 3 },
                    { 2, 4 },
                    { 3, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorOption_ProductId",
                table: "ColorOption",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLabel_LabelId",
                table: "ProductLabel",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorOption");

            migrationBuilder.DropTable(
                name: "ProductLabel");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
