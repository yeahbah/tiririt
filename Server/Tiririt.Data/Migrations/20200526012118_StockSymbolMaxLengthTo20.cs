using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class StockSymbolMaxLengthTo20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "symbol",
                table: "stock",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "symbol",
                table: "stock",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }
    }
}
