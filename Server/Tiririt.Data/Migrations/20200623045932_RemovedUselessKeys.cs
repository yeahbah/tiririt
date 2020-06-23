using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class RemovedUselessKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "post_stock_id",
                table: "post_stock");

            migrationBuilder.DropColumn(
                name: "post_hash_tag_id",
                table: "post_hash_tag");

            migrationBuilder.DropColumn(
                name: "mention_id",
                table: "mention");

            migrationBuilder.DropColumn(
                name: "like_dislike_post_id",
                table: "like_dislike_post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "post_stock_id",
                table: "post_stock",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "post_hash_tag_id",
                table: "post_hash_tag",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "mention_id",
                table: "mention",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "like_dislike_post_id",
                table: "like_dislike_post",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
