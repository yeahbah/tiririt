using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tiririt.Data.Migrations
{
    public partial class BullBearLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bull_bear_level_code_id",
                table: "tiririt_post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "bull_bear_level_code",
                columns: table => new
                {
                    bull_bear_level_code_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bull_bear_level_cd = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bull_bear_level_code", x => x.bull_bear_level_code_id);
                    table.UniqueConstraint("ak_bull_bear_level_code_bull_bear_level_cd", x => x.bull_bear_level_cd);
                });

            migrationBuilder.InsertData(
                table: "bull_bear_level_code",
                columns: new[] { "bull_bear_level_code_id", "bull_bear_level_cd" },
                values: new object[,]
                {
                    { 1, "Neutral" },
                    { 2, "SomewhatBullish" },
                    { 3, "Bullish" },
                    { 4, "VeryBullish" },
                    { 5, "SomewhatBearish" },
                    { 6, "Bearish" },
                    { 7, "VeryBearish" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_tiririt_post_bull_bear_level_code_id",
                table: "tiririt_post",
                column: "bull_bear_level_code_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tiririt_post_bull_bear_level_code_bull_bear_level_code_id",
                table: "tiririt_post",
                column: "bull_bear_level_code_id",
                principalTable: "bull_bear_level_code",
                principalColumn: "bull_bear_level_code_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tiririt_post_bull_bear_level_code_bull_bear_level_code_id",
                table: "tiririt_post");

            migrationBuilder.DropTable(
                name: "bull_bear_level_code");

            migrationBuilder.DropIndex(
                name: "ix_tiririt_post_bull_bear_level_code_id",
                table: "tiririt_post");

            migrationBuilder.DropColumn(
                name: "bull_bear_level_code_id",
                table: "tiririt_post");
        }
    }
}
