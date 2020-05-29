using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class AddPostdeletedindicator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deleted_ind",
                table: "tiririt_post",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deleted_ind",
                table: "post_stock",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "deleted_ind",
                table: "post_hash_tag",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_ind",
                table: "tiririt_post");

            migrationBuilder.DropColumn(
                name: "deleted_ind",
                table: "post_stock");

            migrationBuilder.DropColumn(
                name: "deleted_ind",
                table: "post_hash_tag");
        }
    }
}
