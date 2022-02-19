using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class ChangeLang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observed_Category_CategoryId",
                table: "Observed");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.RenameColumn(
                name: "Zysk",
                table: "Observed",
                newName: "PurchasePrice");

            migrationBuilder.RenameColumn(
                name: "Walor",
                table: "Observed",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "LiczbaAkcji",
                table: "Observed",
                newName: "NumberOfActions");

            migrationBuilder.RenameColumn(
                name: "CenaZakupu",
                table: "Observed",
                newName: "Profit");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Observed",
                newName: "MarketId");

            migrationBuilder.RenameIndex(
                name: "IX_Observed_CategoryId",
                table: "Observed",
                newName: "IX_Observed_MarketId");

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Change = table.Column<float>(type: "real", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Observed_Market_MarketId",
                table: "Observed",
                column: "MarketId",
                principalTable: "Market",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observed_Market_MarketId",
                table: "Observed");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Observed",
                newName: "Walor");

            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "Observed",
                newName: "Zysk");

            migrationBuilder.RenameColumn(
                name: "Profit",
                table: "Observed",
                newName: "CenaZakupu");

            migrationBuilder.RenameColumn(
                name: "NumberOfActions",
                table: "Observed",
                newName: "LiczbaAkcji");

            migrationBuilder.RenameColumn(
                name: "MarketId",
                table: "Observed",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Observed_MarketId",
                table: "Observed",
                newName: "IX_Observed_CategoryId");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Czas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kurs = table.Column<float>(type: "real", nullable: false),
                    Walor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zmiana = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Observed_Category_CategoryId",
                table: "Observed",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
