using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zmiana",
                table: "Observed",
                newName: "CenaZakupu");

            migrationBuilder.AddColumn<int>(
                name: "LiczbaAkcji",
                table: "Observed",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiczbaAkcji",
                table: "Observed");

            migrationBuilder.RenameColumn(
                name: "CenaZakupu",
                table: "Observed",
                newName: "Zmiana");
        }
    }
}
