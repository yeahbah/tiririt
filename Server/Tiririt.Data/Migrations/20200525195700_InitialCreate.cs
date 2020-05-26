using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tiririt.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hash_tag",
                columns: table => new
                {
                    hash_tag_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hash_tag_text = table.Column<string>(maxLength: 20, nullable: false),
                    tiririt_post_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hash_tag", x => x.hash_tag_id);
                });

            migrationBuilder.CreateTable(
                name: "stock_sector",
                columns: table => new
                {
                    stock_sector_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sector_name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock_sector", x => x.stock_sector_id);
                });

            migrationBuilder.CreateTable(
                name: "tiririt_user",
                columns: table => new
                {
                    tiririt_user_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(nullable: false),
                    email_address = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    birth_dt = table.Column<DateTime>(nullable: true),
                    register_dt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tiririt_user", x => x.tiririt_user_id);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    stock_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    symbol = table.Column<string>(maxLength: 10, nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    sector_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock", x => x.stock_id);
                    table.ForeignKey(
                        name: "FK_stock_stock_sector_sector_id",
                        column: x => x.sector_id,
                        principalTable: "stock_sector",
                        principalColumn: "stock_sector_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tiririt_post",
                columns: table => new
                {
                    tiririt_post_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    post_text = table.Column<string>(nullable: false),
                    tiririt_user_id = table.Column<int>(nullable: false),
                    response_to_post_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tiririt_post", x => x.tiririt_post_id);
                    table.ForeignKey(
                        name: "FK_tiririt_post_tiririt_post_response_to_post_id",
                        column: x => x.response_to_post_id,
                        principalTable: "tiririt_post",
                        principalColumn: "tiririt_post_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tiririt_post_tiririt_user_tiririt_user_id",
                        column: x => x.tiririt_user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "tiririt_user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "watch_list",
                columns: table => new
                {
                    watch_list_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    watch_list_name = table.Column<string>(maxLength: 100, nullable: false),
                    tiririt_user_id = table.Column<int>(nullable: false),
                    ref_tiririt_user_tiririt_user_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_watch_list", x => x.watch_list_id);
                    table.ForeignKey(
                        name: "FK_watch_list_tiririt_user_ref_tiririt_user_tiririt_user_id",
                        column: x => x.ref_tiririt_user_tiririt_user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "tiririt_user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stock_quote",
                columns: table => new
                {
                    stock_eod_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    trade_date = table.Column<DateTime>(nullable: false),
                    open = table.Column<decimal>(nullable: false),
                    high = table.Column<decimal>(nullable: false),
                    low = table.Column<decimal>(nullable: false),
                    close = table.Column<decimal>(nullable: false),
                    net_foreign_buy = table.Column<decimal>(nullable: true),
                    stock_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock_quote", x => x.stock_eod_id);
                    table.ForeignKey(
                        name: "FK_stock_quote_stock_stock_id",
                        column: x => x.stock_id,
                        principalTable: "stock",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_hash_tag",
                columns: table => new
                {
                    hash_tag_id = table.Column<int>(nullable: false),
                    tiririt_post_id = table.Column<int>(nullable: false),
                    post_hash_tag_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_post_hash_tag", x => new { x.tiririt_post_id, x.hash_tag_id });
                    table.ForeignKey(
                        name: "FK_post_hash_tag_hash_tag_hash_tag_id",
                        column: x => x.hash_tag_id,
                        principalTable: "hash_tag",
                        principalColumn: "hash_tag_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_hash_tag_tiririt_post_tiririt_post_id",
                        column: x => x.tiririt_post_id,
                        principalTable: "tiririt_post",
                        principalColumn: "tiririt_post_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_stock",
                columns: table => new
                {
                    post_stock_id = table.Column<int>(nullable: false),
                    tiririt_post_id = table.Column<int>(nullable: false),
                    stock_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_post_stock", x => new { x.post_stock_id, x.tiririt_post_id });
                    table.ForeignKey(
                        name: "FK_post_stock_stock_stock_id",
                        column: x => x.stock_id,
                        principalTable: "stock",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_stock_tiririt_post_tiririt_post_id",
                        column: x => x.tiririt_post_id,
                        principalTable: "tiririt_post",
                        principalColumn: "tiririt_post_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "watch_list_stock",
                columns: table => new
                {
                    watch_list_stock_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stock_id = table.Column<string>(nullable: false),
                    ref_stock_stock_id = table.Column<int>(nullable: true),
                    ref_watch_list_watch_list_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_watch_list_stock", x => x.watch_list_stock_id);
                    table.ForeignKey(
                        name: "FK_watch_list_stock_stock_ref_stock_stock_id",
                        column: x => x.ref_stock_stock_id,
                        principalTable: "stock",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_watch_list_stock_watch_list_ref_watch_list_watch_list_id",
                        column: x => x.ref_watch_list_watch_list_id,
                        principalTable: "watch_list",
                        principalColumn: "watch_list_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_post_hash_tag_hash_tag_id",
                table: "post_hash_tag",
                column: "hash_tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_post_stock_stock_id",
                table: "post_stock",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_post_stock_tiririt_post_id",
                table: "post_stock",
                column: "tiririt_post_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_sector_id",
                table: "stock",
                column: "sector_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_quote_stock_id",
                table: "stock_quote",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_tiririt_post_response_to_post_id",
                table: "tiririt_post",
                column: "response_to_post_id");

            migrationBuilder.CreateIndex(
                name: "ix_tiririt_post_tiririt_user_id",
                table: "tiririt_post",
                column: "tiririt_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_ref_tiririt_user_tiririt_user_id",
                table: "watch_list",
                column: "ref_tiririt_user_tiririt_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_stock_ref_stock_stock_id",
                table: "watch_list_stock",
                column: "ref_stock_stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_stock_ref_watch_list_watch_list_id",
                table: "watch_list_stock",
                column: "ref_watch_list_watch_list_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post_hash_tag");

            migrationBuilder.DropTable(
                name: "post_stock");

            migrationBuilder.DropTable(
                name: "stock_quote");

            migrationBuilder.DropTable(
                name: "watch_list_stock");

            migrationBuilder.DropTable(
                name: "hash_tag");

            migrationBuilder.DropTable(
                name: "tiririt_post");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "watch_list");

            migrationBuilder.DropTable(
                name: "stock_sector");

            migrationBuilder.DropTable(
                name: "tiririt_user");
        }
    }
}
