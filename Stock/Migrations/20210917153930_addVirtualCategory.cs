using Microsoft.EntityFrameworkCore.Migrations;

namespace Stock.Migrations
{
    public partial class addVirtualCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Observed",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Observed_CategoryId",
                table: "Observed",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Observed_Category_CategoryId",
                table: "Observed",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Observed_Category_CategoryId",
                table: "Observed");

            migrationBuilder.DropIndex(
                name: "IX_Observed_CategoryId",
                table: "Observed");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Observed");
        }
    }
}
