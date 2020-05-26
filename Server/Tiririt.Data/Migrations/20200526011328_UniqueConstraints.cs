using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tiririt.Data.Migrations
{
    public partial class UniqueConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_stock_quote",
                table: "stock_quote");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "tiririt_user");

            migrationBuilder.DropColumn(
                name: "stock_eod_id",
                table: "stock_quote");

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "tiririt_user",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "stock_quote_id",
                table: "stock_quote",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddUniqueConstraint(
                name: "ak_tiririt_user_email_address",
                table: "tiririt_user",
                column: "email_address");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_tiririt_user_user_name",
                table: "tiririt_user",
                column: "user_name");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stock_sector_sector_name",
                table: "stock_sector",
                column: "sector_name");

            migrationBuilder.AddPrimaryKey(
                name: "pk_stock_quote",
                table: "stock_quote",
                column: "stock_quote_id");

            migrationBuilder.AddUniqueConstraint(
                name: "ak_stock_symbol",
                table: "stock",
                column: "symbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "ak_tiririt_user_email_address",
                table: "tiririt_user");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_tiririt_user_user_name",
                table: "tiririt_user");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stock_sector_sector_name",
                table: "stock_sector");

            migrationBuilder.DropPrimaryKey(
                name: "pk_stock_quote",
                table: "stock_quote");

            migrationBuilder.DropUniqueConstraint(
                name: "ak_stock_symbol",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "tiririt_user");

            migrationBuilder.DropColumn(
                name: "stock_quote_id",
                table: "stock_quote");

            migrationBuilder.AddColumn<string>(
                name: "user_id",
                table: "tiririt_user",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "stock_eod_id",
                table: "stock_quote",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_stock_quote",
                table: "stock_quote",
                column: "stock_eod_id");
        }
    }
}
