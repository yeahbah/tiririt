using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class RemovePostIdFromHashTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_hash_tag_hash_tag_hash_tag_id",
                table: "post_hash_tag");

            migrationBuilder.DropPrimaryKey(
                name: "pk_hash_tag",
                table: "hash_tag");

            migrationBuilder.DropColumn(
                name: "tiririt_post_id",
                table: "hash_tag");

            migrationBuilder.RenameTable(
                name: "hash_tag",
                newName: "hash_tags");

            migrationBuilder.AddPrimaryKey(
                name: "pk_hash_tags",
                table: "hash_tags",
                column: "hash_tag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_hash_tag_hash_tags_hash_tag_id",
                table: "post_hash_tag",
                column: "hash_tag_id",
                principalTable: "hash_tags",
                principalColumn: "hash_tag_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_post_hash_tag_hash_tags_hash_tag_id",
                table: "post_hash_tag");

            migrationBuilder.DropPrimaryKey(
                name: "pk_hash_tags",
                table: "hash_tags");

            migrationBuilder.RenameTable(
                name: "hash_tags",
                newName: "hash_tag");

            migrationBuilder.AddColumn<int>(
                name: "tiririt_post_id",
                table: "hash_tag",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_hash_tag",
                table: "hash_tag",
                column: "hash_tag_id");

            migrationBuilder.AddForeignKey(
                name: "FK_post_hash_tag_hash_tag_hash_tag_id",
                table: "post_hash_tag",
                column: "hash_tag_id",
                principalTable: "hash_tag",
                principalColumn: "hash_tag_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
