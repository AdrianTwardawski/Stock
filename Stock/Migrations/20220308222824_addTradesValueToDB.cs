using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class addTradesValueToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TradesValue",
                table: "Market",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TradesValue",
                table: "Market");
        }
    }
}
