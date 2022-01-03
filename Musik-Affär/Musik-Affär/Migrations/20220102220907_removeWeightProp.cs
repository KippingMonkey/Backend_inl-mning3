using Microsoft.EntityFrameworkCore.Migrations;

namespace Musik_Affär.Migrations
{
    public partial class removeWeightProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Products");

            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Products",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Score",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55,
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
