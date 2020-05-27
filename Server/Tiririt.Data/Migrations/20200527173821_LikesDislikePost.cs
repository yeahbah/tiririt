using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class LikesDislikePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "like_dislike_post",
                columns: table => new
                {
                    tiririt_user_id = table.Column<int>(nullable: false),
                    tiririt_post_id = table.Column<int>(nullable: false),
                    like_dislike_post_id = table.Column<int>(nullable: false),
                    user_like_ind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_like_dislike_post", x => new { x.tiririt_user_id, x.tiririt_post_id });
                    table.ForeignKey(
                        name: "FK_like_dislike_post_tiririt_post_tiririt_post_id",
                        column: x => x.tiririt_post_id,
                        principalTable: "tiririt_post",
                        principalColumn: "tiririt_post_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_like_dislike_post_tiririt_user_tiririt_user_id",
                        column: x => x.tiririt_user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "tiririt_user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_like_dislike_post_tiririt_post_id",
                table: "like_dislike_post",
                column: "tiririt_post_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "like_dislike_post");
        }
    }
}
