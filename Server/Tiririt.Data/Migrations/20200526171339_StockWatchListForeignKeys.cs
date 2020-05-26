using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class StockWatchListForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watch_list_stock_stock_ref_stock_stock_id",
                table: "watch_list_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_watch_list_stock_watch_list_ref_watch_list_watch_list_id",
                table: "watch_list_stock");

            migrationBuilder.DropIndex(
                name: "ix_watch_list_stock_ref_stock_stock_id",
                table: "watch_list_stock");

            migrationBuilder.DropIndex(
                name: "ix_watch_list_stock_ref_watch_list_watch_list_id",
                table: "watch_list_stock");

            migrationBuilder.DropColumn(
                name: "ref_stock_stock_id",
                table: "watch_list_stock");

            migrationBuilder.DropColumn(
                name: "ref_watch_list_watch_list_id",
                table: "watch_list_stock");

            migrationBuilder.AlterColumn<int>(
                name: "stock_id",
                table: "watch_list_stock",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "watch_list_id",
                table: "watch_list_stock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_stock_stock_id",
                table: "watch_list_stock",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_stock_watch_list_id",
                table: "watch_list_stock",
                column: "watch_list_id");

            migrationBuilder.AddForeignKey(
                name: "FK_watch_list_stock_stock_stock_id",
                table: "watch_list_stock",
                column: "stock_id",
                principalTable: "stock",
                principalColumn: "stock_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_watch_list_stock_watch_list_watch_list_id",
                table: "watch_list_stock",
                column: "watch_list_id",
                principalTable: "watch_list",
                principalColumn: "watch_list_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watch_list_stock_stock_stock_id",
                table: "watch_list_stock");

            migrationBuilder.DropForeignKey(
                name: "FK_watch_list_stock_watch_list_watch_list_id",
                table: "watch_list_stock");

            migrationBuilder.DropIndex(
                name: "ix_watch_list_stock_stock_id",
                table: "watch_list_stock");

            migrationBuilder.DropIndex(
                name: "ix_watch_list_stock_watch_list_id",
                table: "watch_list_stock");

            migrationBuilder.DropColumn(
                name: "watch_list_id",
                table: "watch_list_stock");

            // migrationBuilder.AlterColumn<string>(
            //     name: "stock_id",
            //     table: "watch_list_stock",
            //     type: "text",
            //     nullable: false,
            //     oldClrType: typeof(int));            
            migrationBuilder.Sql("ALTER TABLE WATCH_LIST_STOCK ALTER COLUMN STOCK_ID TYPE INTEGER USING (STOCK_ID::integer)");

            migrationBuilder.AddColumn<int>(
                name: "ref_stock_stock_id",
                table: "watch_list_stock",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ref_watch_list_watch_list_id",
                table: "watch_list_stock",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_stock_ref_stock_stock_id",
                table: "watch_list_stock",
                column: "ref_stock_stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_stock_ref_watch_list_watch_list_id",
                table: "watch_list_stock",
                column: "ref_watch_list_watch_list_id");

            migrationBuilder.AddForeignKey(
                name: "FK_watch_list_stock_stock_ref_stock_stock_id",
                table: "watch_list_stock",
                column: "ref_stock_stock_id",
                principalTable: "stock",
                principalColumn: "stock_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_watch_list_stock_watch_list_ref_watch_list_watch_list_id",
                table: "watch_list_stock",
                column: "ref_watch_list_watch_list_id",
                principalTable: "watch_list",
                principalColumn: "watch_list_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
