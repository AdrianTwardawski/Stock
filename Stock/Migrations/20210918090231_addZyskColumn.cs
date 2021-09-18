using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class addZyskColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Zysk",
                table: "Observed",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zysk",
                table: "Observed");
        }
    }
}
