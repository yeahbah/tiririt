using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tiririt.Data.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asp_net_roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bull_bear_level_code",
                columns: table => new
                {
                    bull_bear_level_code_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    bull_bear_level_cd = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bull_bear_level_code", x => x.bull_bear_level_code_id);
                    table.UniqueConstraint("ak_bull_bear_level_code_bull_bear_level_cd", x => x.bull_bear_level_cd);
                });

            migrationBuilder.CreateTable(
                name: "device_codes",
                columns: table => new
                {
                    user_code = table.Column<string>(maxLength: 200, nullable: false),
                    device_code = table.Column<string>(maxLength: 200, nullable: false),
                    subject_id = table.Column<string>(maxLength: 200, nullable: true),
                    client_id = table.Column<string>(maxLength: 200, nullable: false),
                    creation_time = table.Column<DateTime>(nullable: false),
                    expiration = table.Column<DateTime>(nullable: false),
                    data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_codes", x => x.user_code);
                });

            migrationBuilder.CreateTable(
                name: "hash_tag",
                columns: table => new
                {
                    hash_tag_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hash_tag_text = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_hash_tag", x => x.hash_tag_id);
                });

            migrationBuilder.CreateTable(
                name: "persisted_grants",
                columns: table => new
                {
                    key = table.Column<string>(maxLength: 200, nullable: false),
                    type = table.Column<string>(maxLength: 50, nullable: false),
                    subject_id = table.Column<string>(maxLength: 200, nullable: true),
                    client_id = table.Column<string>(maxLength: 200, nullable: false),
                    creation_time = table.Column<DateTime>(nullable: false),
                    expiration = table.Column<DateTime>(nullable: true),
                    data = table.Column<string>(maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persisted_grants", x => x.key);
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
                    table.UniqueConstraint("ak_stock_sector_sector_name", x => x.sector_name);
                });

            migrationBuilder.CreateTable(
                name: "tiririt_user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(maxLength: 256, nullable: true),
                    email = table.Column<string>(maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(nullable: false),
                    password_hash = table.Column<string>(nullable: true),
                    security_stamp = table.Column<string>(nullable: true),
                    concurrency_stamp = table.Column<string>(nullable: true),
                    phone_number = table.Column<string>(nullable: true),
                    phone_number_confirmed = table.Column<bool>(nullable: false),
                    two_factor_enabled = table.Column<bool>(nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(nullable: true),
                    lockout_enabled = table.Column<bool>(nullable: false),
                    access_failed_count = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(maxLength: 50, nullable: false),
                    last_name = table.Column<string>(maxLength: 50, nullable: false),
                    birth_dt = table.Column<DateTime>(nullable: true),
                    register_dt = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tiririt_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    stock_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    symbol = table.Column<string>(maxLength: 20, nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    sector_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock", x => x.stock_id);
                    table.UniqueConstraint("ak_stock_symbol", x => x.symbol);
                    table.ForeignKey(
                        name: "FK_stock_stock_sector_sector_id",
                        column: x => x.sector_id,
                        principalTable: "stock_sector",
                        principalColumn: "stock_sector_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(nullable: false),
                    claim_type = table.Column<string>(nullable: true),
                    claim_value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "FK_asp_net_user_claims_tiririt_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(nullable: false),
                    provider_key = table.Column<string>(nullable: false),
                    provider_display_name = table.Column<string>(nullable: true),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "FK_asp_net_user_logins_tiririt_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_roles",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asp_net_user_roles_tiririt_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_tokens",
                columns: table => new
                {
                    user_id = table.Column<int>(nullable: false),
                    login_provider = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "FK_asp_net_user_tokens_tiririt_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "id",
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
                    response_to_post_id = table.Column<int>(nullable: true),
                    post_date = table.Column<DateTime>(nullable: false),
                    modified_date = table.Column<DateTime>(nullable: true),
                    bull_bear_level_code_id = table.Column<int>(nullable: false),
                    deleted_ind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tiririt_post", x => x.tiririt_post_id);
                    table.ForeignKey(
                        name: "FK_tiririt_post_bull_bear_level_code_bull_bear_level_code_id",
                        column: x => x.bull_bear_level_code_id,
                        principalTable: "bull_bear_level_code",
                        principalColumn: "bull_bear_level_code_id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "id",
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
                    deleted_ind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_watch_list", x => x.watch_list_id);
                    table.ForeignKey(
                        name: "FK_watch_list_tiririt_user_tiririt_user_id",
                        column: x => x.tiririt_user_id,
                        principalTable: "tiririt_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stock_quote",
                columns: table => new
                {
                    stock_quote_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    trade_date = table.Column<DateTime>(type: "date", nullable: false),
                    open = table.Column<decimal>(nullable: false),
                    high = table.Column<decimal>(nullable: false),
                    low = table.Column<decimal>(nullable: false),
                    close = table.Column<decimal>(nullable: false),
                    volumne = table.Column<long>(nullable: false),
                    net_foreign_buy = table.Column<decimal>(nullable: true),
                    stock_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stock_quote", x => x.stock_quote_id);
                    table.ForeignKey(
                        name: "FK_stock_quote_stock_stock_id",
                        column: x => x.stock_id,
                        principalTable: "stock",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "like_dislike_post",
                columns: table => new
                {
                    tiririt_user_id = table.Column<int>(nullable: false),
                    tiririt_post_id = table.Column<int>(nullable: false),
                    like_dislike_post_id = table.Column<int>(nullable: false),
                    user_like_ind = table.Column<int>(nullable: false),
                    deleted_ind = table.Column<int>(nullable: false)
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_hash_tag",
                columns: table => new
                {
                    hash_tag_id = table.Column<int>(nullable: false),
                    tiririt_post_id = table.Column<int>(nullable: false),
                    post_hash_tag_id = table.Column<int>(nullable: false),
                    deleted_ind = table.Column<int>(nullable: false)
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
                    tiririt_post_id = table.Column<int>(nullable: false),
                    stock_id = table.Column<int>(nullable: false),
                    post_stock_id = table.Column<int>(nullable: false),
                    deleted_ind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_post_stock", x => new { x.stock_id, x.tiririt_post_id });
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
                    stock_id = table.Column<int>(nullable: false),
                    watch_list_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_watch_list_stock", x => x.watch_list_stock_id);
                    table.ForeignKey(
                        name: "FK_watch_list_stock_stock_stock_id",
                        column: x => x.stock_id,
                        principalTable: "stock",
                        principalColumn: "stock_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_watch_list_stock_watch_list_watch_list_id",
                        column: x => x.watch_list_id,
                        principalTable: "watch_list",
                        principalColumn: "watch_list_id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ix_asp_net_role_claims_role_id",
                table: "asp_net_role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "role_name_index",
                table: "asp_net_roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "asp_net_user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "asp_net_user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "asp_net_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_device_code",
                table: "device_codes",
                column: "device_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_device_codes_expiration",
                table: "device_codes",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_like_dislike_post_tiririt_post_id",
                table: "like_dislike_post",
                column: "tiririt_post_id");

            migrationBuilder.CreateIndex(
                name: "ix_mention_tiririt_user_id",
                table: "mention",
                column: "tiririt_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_expiration",
                table: "persisted_grants",
                column: "expiration");

            migrationBuilder.CreateIndex(
                name: "ix_persisted_grants_subject_id_client_id_type",
                table: "persisted_grants",
                columns: new[] { "subject_id", "client_id", "type" });

            migrationBuilder.CreateIndex(
                name: "ix_post_hash_tag_hash_tag_id",
                table: "post_hash_tag",
                column: "hash_tag_id");

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
                name: "ix_tiririt_post_bull_bear_level_code_id",
                table: "tiririt_post",
                column: "bull_bear_level_code_id");

            migrationBuilder.CreateIndex(
                name: "ix_tiririt_post_response_to_post_id",
                table: "tiririt_post",
                column: "response_to_post_id");

            migrationBuilder.CreateIndex(
                name: "ix_tiririt_post_tiririt_user_id",
                table: "tiririt_post",
                column: "tiririt_user_id");

            migrationBuilder.CreateIndex(
                name: "email_index",
                table: "tiririt_user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "user_name_index",
                table: "tiririt_user",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_tiririt_user_id",
                table: "watch_list",
                column: "tiririt_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_stock_stock_id",
                table: "watch_list_stock",
                column: "stock_id");

            migrationBuilder.CreateIndex(
                name: "ix_watch_list_stock_watch_list_id",
                table: "watch_list_stock",
                column: "watch_list_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asp_net_role_claims");

            migrationBuilder.DropTable(
                name: "asp_net_user_claims");

            migrationBuilder.DropTable(
                name: "asp_net_user_logins");

            migrationBuilder.DropTable(
                name: "asp_net_user_roles");

            migrationBuilder.DropTable(
                name: "asp_net_user_tokens");

            migrationBuilder.DropTable(
                name: "device_codes");

            migrationBuilder.DropTable(
                name: "like_dislike_post");

            migrationBuilder.DropTable(
                name: "mention");

            migrationBuilder.DropTable(
                name: "persisted_grants");

            migrationBuilder.DropTable(
                name: "post_hash_tag");

            migrationBuilder.DropTable(
                name: "post_stock");

            migrationBuilder.DropTable(
                name: "stock_quote");

            migrationBuilder.DropTable(
                name: "watch_list_stock");

            migrationBuilder.DropTable(
                name: "asp_net_roles");

            migrationBuilder.DropTable(
                name: "hash_tag");

            migrationBuilder.DropTable(
                name: "tiririt_post");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "watch_list");

            migrationBuilder.DropTable(
                name: "bull_bear_level_code");

            migrationBuilder.DropTable(
                name: "stock_sector");

            migrationBuilder.DropTable(
                name: "tiririt_user");
        }
    }
}
