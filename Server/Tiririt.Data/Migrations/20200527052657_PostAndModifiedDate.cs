using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiririt.Data.Migrations
{
    public partial class PostAndModifiedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "modified_date",
                table: "tiririt_post",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "post_date",
                table: "tiririt_post",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "modified_date",
                table: "tiririt_post");

            migrationBuilder.DropColumn(
                name: "post_date",
                table: "tiririt_post");
        }
    }
}
