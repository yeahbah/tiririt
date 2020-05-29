using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class FixedWrongPostStockKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_post_stock",
                table: "post_stock");

            migrationBuilder.DropIndex(
                name: "ix_post_stock_stock_id",
                table: "post_stock");

            migrationBuilder.AddPrimaryKey(
                name: "pk_post_stock",
                table: "post_stock",
                columns: new[] { "stock_id", "tiririt_post_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_post_stock",
                table: "post_stock");

            migrationBuilder.AddPrimaryKey(
                name: "pk_post_stock",
                table: "post_stock",
                columns: new[] { "post_stock_id", "tiririt_post_id" });

            migrationBuilder.CreateIndex(
                name: "ix_post_stock_stock_id",
                table: "post_stock",
                column: "stock_id");
        }
    }
}
