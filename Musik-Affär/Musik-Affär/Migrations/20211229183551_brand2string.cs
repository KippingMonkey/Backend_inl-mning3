using Microsoft.EntityFrameworkCore.Migrations;

namespace Musik_Affär.Migrations
{
    public partial class brand2string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 55);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "Products",
                type: "int",
                maxLength: 55,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);
        }
    }
}
