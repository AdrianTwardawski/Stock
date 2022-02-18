using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KursFloat",
                table: "Category");

            migrationBuilder.AlterColumn<float>(
                name: "Kurs",
                table: "Category",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Kurs",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "KursFloat",
                table: "Category",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
