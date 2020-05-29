using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    ProductInStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.ProductInStockId);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 621m },
                    { 73, "Description for product 73", "Product 73", 260m },
                    { 72, "Description for product 72", "Product 72", 648m },
                    { 71, "Description for product 71", "Product 71", 331m },
                    { 70, "Description for product 70", "Product 70", 463m },
                    { 69, "Description for product 69", "Product 69", 200m },
                    { 68, "Description for product 68", "Product 68", 632m },
                    { 67, "Description for product 67", "Product 67", 580m },
                    { 66, "Description for product 66", "Product 66", 404m },
                    { 65, "Description for product 65", "Product 65", 248m },
                    { 64, "Description for product 64", "Product 64", 888m },
                    { 63, "Description for product 63", "Product 63", 381m },
                    { 62, "Description for product 62", "Product 62", 782m },
                    { 61, "Description for product 61", "Product 61", 809m },
                    { 60, "Description for product 60", "Product 60", 757m },
                    { 59, "Description for product 59", "Product 59", 493m },
                    { 58, "Description for product 58", "Product 58", 226m },
                    { 57, "Description for product 57", "Product 57", 696m },
                    { 56, "Description for product 56", "Product 56", 167m },
                    { 55, "Description for product 55", "Product 55", 619m },
                    { 54, "Description for product 54", "Product 54", 190m },
                    { 53, "Description for product 53", "Product 53", 203m },
                    { 74, "Description for product 74", "Product 74", 243m },
                    { 52, "Description for product 52", "Product 52", 333m },
                    { 75, "Description for product 75", "Product 75", 965m },
                    { 77, "Description for product 77", "Product 77", 171m },
                    { 98, "Description for product 98", "Product 98", 593m },
                    { 97, "Description for product 97", "Product 97", 651m },
                    { 96, "Description for product 96", "Product 96", 949m },
                    { 95, "Description for product 95", "Product 95", 672m },
                    { 94, "Description for product 94", "Product 94", 515m },
                    { 93, "Description for product 93", "Product 93", 292m },
                    { 92, "Description for product 92", "Product 92", 964m },
                    { 91, "Description for product 91", "Product 91", 939m },
                    { 90, "Description for product 90", "Product 90", 215m },
                    { 89, "Description for product 89", "Product 89", 686m },
                    { 88, "Description for product 88", "Product 88", 551m },
                    { 87, "Description for product 87", "Product 87", 568m },
                    { 86, "Description for product 86", "Product 86", 798m },
                    { 85, "Description for product 85", "Product 85", 175m },
                    { 84, "Description for product 84", "Product 84", 353m },
                    { 83, "Description for product 83", "Product 83", 940m },
                    { 82, "Description for product 82", "Product 82", 185m },
                    { 81, "Description for product 81", "Product 81", 499m },
                    { 80, "Description for product 80", "Product 80", 895m },
                    { 79, "Description for product 79", "Product 79", 619m },
                    { 78, "Description for product 78", "Product 78", 281m },
                    { 76, "Description for product 76", "Product 76", 258m },
                    { 51, "Description for product 51", "Product 51", 829m },
                    { 50, "Description for product 50", "Product 50", 827m },
                    { 49, "Description for product 49", "Product 49", 132m },
                    { 22, "Description for product 22", "Product 22", 553m },
                    { 21, "Description for product 21", "Product 21", 191m },
                    { 20, "Description for product 20", "Product 20", 698m },
                    { 19, "Description for product 19", "Product 19", 625m },
                    { 18, "Description for product 18", "Product 18", 432m },
                    { 17, "Description for product 17", "Product 17", 334m },
                    { 16, "Description for product 16", "Product 16", 422m },
                    { 15, "Description for product 15", "Product 15", 998m },
                    { 14, "Description for product 14", "Product 14", 383m },
                    { 13, "Description for product 13", "Product 13", 838m },
                    { 12, "Description for product 12", "Product 12", 222m },
                    { 11, "Description for product 11", "Product 11", 976m },
                    { 10, "Description for product 10", "Product 10", 280m },
                    { 9, "Description for product 9", "Product 9", 793m },
                    { 8, "Description for product 8", "Product 8", 463m },
                    { 7, "Description for product 7", "Product 7", 755m },
                    { 6, "Description for product 6", "Product 6", 134m },
                    { 5, "Description for product 5", "Product 5", 282m },
                    { 4, "Description for product 4", "Product 4", 110m },
                    { 3, "Description for product 3", "Product 3", 504m },
                    { 2, "Description for product 2", "Product 2", 147m },
                    { 23, "Description for product 23", "Product 23", 451m },
                    { 24, "Description for product 24", "Product 24", 378m },
                    { 25, "Description for product 25", "Product 25", 617m },
                    { 26, "Description for product 26", "Product 26", 525m },
                    { 48, "Description for product 48", "Product 48", 239m },
                    { 47, "Description for product 47", "Product 47", 125m },
                    { 46, "Description for product 46", "Product 46", 722m },
                    { 45, "Description for product 45", "Product 45", 758m },
                    { 44, "Description for product 44", "Product 44", 269m },
                    { 43, "Description for product 43", "Product 43", 482m },
                    { 42, "Description for product 42", "Product 42", 932m },
                    { 41, "Description for product 41", "Product 41", 732m },
                    { 40, "Description for product 40", "Product 40", 482m },
                    { 39, "Description for product 39", "Product 39", 272m },
                    { 99, "Description for product 99", "Product 99", 120m },
                    { 38, "Description for product 38", "Product 38", 685m },
                    { 36, "Description for product 36", "Product 36", 635m },
                    { 35, "Description for product 35", "Product 35", 283m },
                    { 34, "Description for product 34", "Product 34", 306m },
                    { 33, "Description for product 33", "Product 33", 642m },
                    { 32, "Description for product 32", "Product 32", 671m },
                    { 31, "Description for product 31", "Product 31", 131m },
                    { 30, "Description for product 30", "Product 30", 905m },
                    { 29, "Description for product 29", "Product 29", 181m },
                    { 28, "Description for product 28", "Product 28", 973m },
                    { 27, "Description for product 27", "Product 27", 325m },
                    { 37, "Description for product 37", "Product 37", 190m },
                    { 100, "Description for product 100", "Product 100", 454m }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "ProductInStockId", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 13 },
                    { 73, 73, 90 },
                    { 72, 72, 64 },
                    { 71, 71, 14 },
                    { 70, 70, 73 },
                    { 69, 69, 33 },
                    { 68, 68, 33 },
                    { 67, 67, 8 },
                    { 66, 66, 17 },
                    { 65, 65, 0 },
                    { 64, 64, 64 },
                    { 63, 63, 44 },
                    { 62, 62, 73 },
                    { 61, 61, 57 },
                    { 60, 60, 52 },
                    { 59, 59, 62 },
                    { 58, 58, 70 },
                    { 57, 57, 91 },
                    { 56, 56, 71 },
                    { 55, 55, 48 },
                    { 54, 54, 80 },
                    { 53, 53, 85 },
                    { 74, 74, 8 },
                    { 52, 52, 97 },
                    { 75, 75, 89 },
                    { 77, 77, 71 },
                    { 98, 98, 5 },
                    { 97, 97, 80 },
                    { 96, 96, 97 },
                    { 95, 95, 73 },
                    { 94, 94, 8 },
                    { 93, 93, 5 },
                    { 92, 92, 91 },
                    { 91, 91, 11 },
                    { 90, 90, 67 },
                    { 89, 89, 55 },
                    { 88, 88, 56 },
                    { 87, 87, 32 },
                    { 86, 86, 39 },
                    { 85, 85, 45 },
                    { 84, 84, 45 },
                    { 83, 83, 46 },
                    { 82, 82, 29 },
                    { 81, 81, 38 },
                    { 80, 80, 94 },
                    { 79, 79, 49 },
                    { 78, 78, 94 },
                    { 76, 76, 60 },
                    { 51, 51, 23 },
                    { 50, 50, 5 },
                    { 49, 49, 13 },
                    { 22, 22, 41 },
                    { 21, 21, 85 },
                    { 20, 20, 60 },
                    { 19, 19, 38 },
                    { 18, 18, 51 },
                    { 17, 17, 33 },
                    { 16, 16, 77 },
                    { 15, 15, 76 },
                    { 14, 14, 72 },
                    { 13, 13, 36 },
                    { 12, 12, 45 },
                    { 11, 11, 35 },
                    { 10, 10, 36 },
                    { 9, 9, 33 },
                    { 8, 8, 95 },
                    { 7, 7, 34 },
                    { 6, 6, 60 },
                    { 5, 5, 63 },
                    { 4, 4, 54 },
                    { 3, 3, 34 },
                    { 2, 2, 96 },
                    { 23, 23, 5 },
                    { 24, 24, 63 },
                    { 25, 25, 91 },
                    { 26, 26, 11 },
                    { 48, 48, 74 },
                    { 47, 47, 73 },
                    { 46, 46, 97 },
                    { 45, 45, 14 },
                    { 44, 44, 10 },
                    { 43, 43, 69 },
                    { 42, 42, 25 },
                    { 41, 41, 71 },
                    { 40, 40, 30 },
                    { 39, 39, 60 },
                    { 99, 99, 10 },
                    { 38, 38, 68 },
                    { 36, 36, 3 },
                    { 35, 35, 39 },
                    { 34, 34, 3 },
                    { 33, 33, 37 },
                    { 32, 32, 17 },
                    { 31, 31, 36 },
                    { 30, 30, 69 },
                    { 29, 29, 51 },
                    { 28, 28, 60 },
                    { 27, 27, 3 },
                    { 37, 37, 62 },
                    { 100, 100, 96 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductId",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductInStockId",
                table: "Stocks",
                column: "ProductInStockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
