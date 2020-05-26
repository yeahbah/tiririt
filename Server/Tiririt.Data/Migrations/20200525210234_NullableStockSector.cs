using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class NullableStockSector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_stock_sector_sector_id",
                table: "stock");

            migrationBuilder.AlterColumn<int>(
                name: "sector_id",
                table: "stock",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_stock_sector_sector_id",
                table: "stock",
                column: "sector_id",
                principalTable: "stock_sector",
                principalColumn: "stock_sector_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_stock_sector_sector_id",
                table: "stock");

            migrationBuilder.AlterColumn<int>(
                name: "sector_id",
                table: "stock",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_stock_sector_sector_id",
                table: "stock",
                column: "sector_id",
                principalTable: "stock_sector",
                principalColumn: "stock_sector_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
