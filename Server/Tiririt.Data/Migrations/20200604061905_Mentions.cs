using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class Mentions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mention",
                columns: table => new
                {
                    tiririt_post_id = table.Column<int>(nullable: false),
                    tiririt_user_id = table.Column<int>(nullable: false),
                    mention_id = table.Column<int>(nullable: false),
                    deleted_ind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_mention", x => new { x.tiririt_post_id, x.tiririt_user_id });
                    table.ForeignKey(
                        name: "FK_mention_tiririt_post_tiririt_post_id",
                        column: x => x.tiririt_post_id,
                        principalTable: "tiririt_post",
                        principalColumn: "tiririt_post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mention_tiririt_user_tiririt_user_id",
                        column: x => x.tiririt_user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "tiririt_user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_mention_tiririt_user_id",
                table: "mention",
                column: "tiririt_user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mention");
        }
    }
}
