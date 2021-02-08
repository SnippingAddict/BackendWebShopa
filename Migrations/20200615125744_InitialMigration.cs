using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categories = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    InStock = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingDetails_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Cart_ShoppingDetails_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ShoppingDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Categories" },
                values: new object[] { 1, "Mobile" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Categories" },
                values: new object[] { 2, "Processor" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Categories" },
                values: new object[] { 3, "Laptop" });

            migrationBuilder.InsertData(
                table: "ShoppingDetails",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "InStock", "ItemName", "Price" },
                values: new object[] { 1, 1, "Solid phone", "https://cdn.shopify.com/s/files/1/0250/3793/0580/products/1_d539c0ca-7985-4c86-b8db-847074480619_1024x1024@2x.png?v=1558174602", 5, "IPhoneXS", 30 });

            migrationBuilder.InsertData(
                table: "ShoppingDetails",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "InStock", "ItemName", "Price" },
                values: new object[] { 2, 2, "Solid processor", "https://cdn.shopify.com/s/files/1/0250/3793/0580/products/1_d539c0ca-7985-4c86-b8db-847074480619_1024x1024@2x.png?v=1558174602", 5, "AMD Ryzen 7 1700", 286 });

            migrationBuilder.InsertData(
                table: "ShoppingDetails",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "InStock", "ItemName", "Price" },
                values: new object[] { 3, 3, "Solid laptop", "https://cdn.shopify.com/s/files/1/0250/3793/0580/products/1_d539c0ca-7985-4c86-b8db-847074480619_1024x1024@2x.png?v=1558174602", 5, "ACER Laptop", 286 });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "ProductId", "Qty" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingDetails_CategoryId",
                table: "ShoppingDetails",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ShoppingDetails");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
