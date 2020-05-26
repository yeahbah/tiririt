using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class WatchListForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watch_list_tiririt_user_ref_tiririt_user_tiririt_user_id",
                table: "watch_list");

            migrationBuilder.DropIndex(
                name: "ix_watch_list_ref_tiririt_user_tiririt_user_id",
                table: "watch_list");

            migrationBuilder.DropColumn(
                name: "ref_tiririt_user_tiririt_user_id",
                table: "watch_list");

            migrationBuilder.AlterColumn<DateTime>(
                name: "trade_date",
                table: "stock_quote",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_tiririt_user_id",
                table: "watch_list",
                column: "tiririt_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_watch_list_tiririt_user_tiririt_user_id",
                table: "watch_list",
                column: "tiririt_user_id",
                principalTable: "tiririt_user",
                principalColumn: "tiririt_user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_watch_list_tiririt_user_tiririt_user_id",
                table: "watch_list");

            migrationBuilder.DropIndex(
                name: "ix_watch_list_tiririt_user_id",
                table: "watch_list");

            migrationBuilder.AddColumn<int>(
                name: "ref_tiririt_user_tiririt_user_id",
                table: "watch_list",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "trade_date",
                table: "stock_quote",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_ref_tiririt_user_tiririt_user_id",
                table: "watch_list",
                column: "ref_tiririt_user_tiririt_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_watch_list_tiririt_user_ref_tiririt_user_tiririt_user_id",
                table: "watch_list",
                column: "ref_tiririt_user_tiririt_user_id",
                principalTable: "tiririt_user",
                principalColumn: "tiririt_user_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
