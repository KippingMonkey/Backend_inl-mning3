using Microsoft.EntityFrameworkCore.Migrations;

namespace Musik_Affär.Migrations
{
    public partial class bridge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductID",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProductID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Carts");

            migrationBuilder.CreateTable(
                name: "CartProduct",
                columns: table => new
                {
                    CartsID = table.Column<int>(type: "int", nullable: false),
                    ProductsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartProduct", x => new { x.CartsID, x.ProductsID });
                    table.ForeignKey(
                        name: "FK_CartProduct_Carts_CartsID",
                        column: x => x.CartsID,
                        principalTable: "Carts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartProduct_Products_ProductsID",
                        column: x => x.ProductsID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartProduct_ProductsID",
                table: "CartProduct",
                column: "ProductsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductID",
                table: "Carts",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductID",
                table: "Carts",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
