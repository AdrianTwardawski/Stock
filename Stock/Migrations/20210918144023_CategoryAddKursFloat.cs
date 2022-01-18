using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class CategoryAddKursFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "KursFloat",
                table: "Category",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KursFloat",
                table: "Category");
        }
    }
}
