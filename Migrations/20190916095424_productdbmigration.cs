using Microsoft.EntityFrameworkCore.Migrations;

namespace Grocery_Store.Migrations
{
    public partial class productdbmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AutoId",
                table: "Product",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 24);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 24);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "AutoId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Product",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
