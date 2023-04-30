using Microsoft.EntityFrameworkCore.Migrations;

namespace IesaNews.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "categories",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
