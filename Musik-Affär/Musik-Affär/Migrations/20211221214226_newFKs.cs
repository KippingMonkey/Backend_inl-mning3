using Microsoft.EntityFrameworkCore.Migrations;

namespace Musik_Affär.Migrations
{
    public partial class newFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductID",
                table: "Reviews",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductID",
                table: "Reviews",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ProductID",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Orders");
        }
    }
}
