using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class addCzasToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Czas",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Czas",
                table: "Category");
        }
    }
}
