﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tiririt.Data.Internal;

namespace Tiririt.Data.Migrations
{
    [DbContext(typeof(TiriritDbContext))]
    [Migration("20200526171339_StockWatchListForeignKeys")]
    partial class StockWatchListForeignKeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Tiririt.Data.Entities.HASH_TAG", b =>
                {
                    b.Property<int>("HASH_TAG_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("hash_tag_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HASH_TAG_TEXT")
                        .IsRequired()
                        .HasColumnName("hash_tag_text")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<int>("TIRIRIT_POST_ID")
                        .HasColumnName("tiririt_post_id")
                        .HasColumnType("integer");

                    b.HasKey("HASH_TAG_ID")
                        .HasName("pk_hash_tag");

                    b.ToTable("hash_tag");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.POST_HASH_TAG", b =>
                {
                    b.Property<int>("TIRIRIT_POST_ID")
                        .HasColumnName("tiririt_post_id")
                        .HasColumnType("integer");

                    b.Property<int>("HASH_TAG_ID")
                        .HasColumnName("hash_tag_id")
                        .HasColumnType("integer");

                    b.Property<int>("POST_HASH_TAG_ID")
                        .HasColumnName("post_hash_tag_id")
                        .HasColumnType("integer");

                    b.HasKey("TIRIRIT_POST_ID", "HASH_TAG_ID")
                        .HasName("pk_post_hash_tag");

                    b.HasIndex("HASH_TAG_ID")
                        .HasName("ix_post_hash_tag_hash_tag_id");

                    b.ToTable("post_hash_tag");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.POST_STOCK", b =>
                {
                    b.Property<int>("POST_STOCK_ID")
                        .HasColumnName("post_stock_id")
                        .HasColumnType("integer");

                    b.Property<int>("TIRIRIT_POST_ID")
                        .HasColumnName("tiririt_post_id")
                        .HasColumnType("integer");

                    b.Property<int>("STOCK_ID")
                        .HasColumnName("stock_id")
                        .HasColumnType("integer");

                    b.HasKey("POST_STOCK_ID", "TIRIRIT_POST_ID")
                        .HasName("pk_post_stock");

                    b.HasIndex("STOCK_ID")
                        .HasName("ix_post_stock_stock_id");

                    b.HasIndex("TIRIRIT_POST_ID")
                        .HasName("ix_post_stock_tiririt_post_id");

                    b.ToTable("post_stock");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.STOCK", b =>
                {
                    b.Property<int>("STOCK_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("stock_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(200)")
                        .HasMaxLength(200);

                    b.Property<int?>("SECTOR_ID")
                        .HasColumnName("sector_id")
                        .HasColumnType("integer");

                    b.Property<string>("SYMBOL")
                        .IsRequired()
                        .HasColumnName("symbol")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.HasKey("STOCK_ID")
                        .HasName("pk_stock");

                    b.HasAlternateKey("SYMBOL")
                        .HasName("ak_stock_symbol");

                    b.HasIndex("SECTOR_ID")
                        .HasName("ix_stock_sector_id");

                    b.ToTable("stock");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.STOCK_QUOTE", b =>
                {
                    b.Property<int>("STOCK_QUOTE_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("stock_quote_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("CLOSE")
                        .HasColumnName("close")
                        .HasColumnType("numeric");

                    b.Property<decimal>("HIGH")
                        .HasColumnName("high")
                        .HasColumnType("numeric");

                    b.Property<decimal>("LOW")
                        .HasColumnName("low")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("NET_FOREIGN_BUY")
                        .HasColumnName("net_foreign_buy")
                        .HasColumnType("numeric");

                    b.Property<decimal>("OPEN")
                        .HasColumnName("open")
                        .HasColumnType("numeric");

                    b.Property<int>("STOCK_ID")
                        .HasColumnName("stock_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TRADE_DATE")
                        .HasColumnName("trade_date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("STOCK_QUOTE_ID")
                        .HasName("pk_stock_quote");

                    b.HasIndex("STOCK_ID")
                        .HasName("ix_stock_quote_stock_id");

                    b.ToTable("stock_quote");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.STOCK_SECTOR", b =>
                {
                    b.Property<int>("STOCK_SECTOR_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("stock_sector_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("SECTOR_NAME")
                        .IsRequired()
                        .HasColumnName("sector_name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("STOCK_SECTOR_ID")
                        .HasName("pk_stock_sector");

                    b.HasAlternateKey("SECTOR_NAME")
                        .HasName("ak_stock_sector_sector_name");

                    b.ToTable("stock_sector");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.TIRIRIT_POST", b =>
                {
                    b.Property<int>("TIRIRIT_POST_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tiririt_post_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("POST_TEXT")
                        .IsRequired()
                        .HasColumnName("post_text")
                        .HasColumnType("text");

                    b.Property<int?>("RESPONSE_TO_POST_ID")
                        .HasColumnName("response_to_post_id")
                        .HasColumnType("integer");

                    b.Property<int>("TIRIRIT_USER_ID")
                        .HasColumnName("tiririt_user_id")
                        .HasColumnType("integer");

                    b.HasKey("TIRIRIT_POST_ID")
                        .HasName("pk_tiririt_post");

                    b.HasIndex("RESPONSE_TO_POST_ID")
                        .HasName("ix_tiririt_post_response_to_post_id");

                    b.HasIndex("TIRIRIT_USER_ID")
                        .HasName("ix_tiririt_post_tiririt_user_id");

                    b.ToTable("tiririt_post");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.TIRIRIT_USER", b =>
                {
                    b.Property<int>("TIRIRIT_USER_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tiririt_user_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("BIRTH_DT")
                        .HasColumnName("birth_dt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EMAIL_ADDRESS")
                        .IsRequired()
                        .HasColumnName("email_address")
                        .HasColumnType("text");

                    b.Property<string>("FIRST_NAME")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LAST_NAME")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PASSWORD")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("text");

                    b.Property<DateTime>("REGISTER_DT")
                        .HasColumnName("register_dt")
                        .HasColumnType("timestamp");

                    b.Property<string>("USER_NAME")
                        .IsRequired()
                        .HasColumnName("user_name")
                        .HasColumnType("text");

                    b.HasKey("TIRIRIT_USER_ID")
                        .HasName("pk_tiririt_user");

                    b.HasAlternateKey("EMAIL_ADDRESS")
                        .HasName("ak_tiririt_user_email_address");

                    b.HasAlternateKey("USER_NAME")
                        .HasName("ak_tiririt_user_user_name");

                    b.ToTable("tiririt_user");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.WATCH_LIST", b =>
                {
                    b.Property<int>("WATCH_LIST_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("watch_list_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Ref_TiriritUserTIRIRIT_USER_ID")
                        .HasColumnName("ref_tiririt_user_tiririt_user_id")
                        .HasColumnType("integer");

                    b.Property<int>("TIRIRIT_USER_ID")
                        .HasColumnName("tiririt_user_id")
                        .HasColumnType("integer");

                    b.Property<string>("WATCH_LIST_NAME")
                        .IsRequired()
                        .HasColumnName("watch_list_name")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("WATCH_LIST_ID")
                        .HasName("pk_watch_list");

                    b.HasIndex("Ref_TiriritUserTIRIRIT_USER_ID")
                        .HasName("ix_watch_list_ref_tiririt_user_tiririt_user_id");

                    b.ToTable("watch_list");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.WATCH_LIST_STOCK", b =>
                {
                    b.Property<int>("WATCH_LIST_STOCK_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("watch_list_stock_id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("STOCK_ID")
                        .HasColumnName("stock_id")
                        .HasColumnType("integer");

                    b.Property<int>("WATCH_LIST_ID")
                        .HasColumnName("watch_list_id")
                        .HasColumnType("integer");

                    b.HasKey("WATCH_LIST_STOCK_ID")
                        .HasName("pk_watch_list_stock");

                    b.HasIndex("STOCK_ID")
                        .HasName("ix_watch_list_stock_stock_id");

                    b.HasIndex("WATCH_LIST_ID")
                        .HasName("ix_watch_list_stock_watch_list_id");

                    b.ToTable("watch_list_stock");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.POST_HASH_TAG", b =>
                {
                    b.HasOne("Tiririt.Data.Entities.HASH_TAG", "Ref_HashTag")
                        .WithMany("Ref_TiriritPosts")
                        .HasForeignKey("HASH_TAG_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tiririt.Data.Entities.TIRIRIT_POST", "Ref_TiriritPost")
                        .WithMany("Ref_HashTags")
                        .HasForeignKey("TIRIRIT_POST_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tiririt.Data.Entities.POST_STOCK", b =>
                {
                    b.HasOne("Tiririt.Data.Entities.STOCK", "Ref_Stock")
                        .WithMany("Ref_TiriritPosts")
                        .HasForeignKey("STOCK_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tiririt.Data.Entities.TIRIRIT_POST", "Ref_TiriritPost")
                        .WithMany("Ref_Stocks")
                        .HasForeignKey("TIRIRIT_POST_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tiririt.Data.Entities.STOCK", b =>
                {
                    b.HasOne("Tiririt.Data.Entities.STOCK_SECTOR", "Ref_Sector")
                        .WithMany("Ref_Stocks")
                        .HasForeignKey("SECTOR_ID");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.STOCK_QUOTE", b =>
                {
                    b.HasOne("Tiririt.Data.Entities.STOCK", "Ref_Stock")
                        .WithMany("Ref_StockQuotes")
                        .HasForeignKey("STOCK_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tiririt.Data.Entities.TIRIRIT_POST", b =>
                {
                    b.HasOne("Tiririt.Data.Entities.TIRIRIT_POST", "Ref_TiriritPost")
                        .WithMany("Ref_Responses")
                        .HasForeignKey("RESPONSE_TO_POST_ID");

                    b.HasOne("Tiririt.Data.Entities.TIRIRIT_USER", "Ref_PostedBy")
                        .WithMany("Ref_TiriritPosts")
                        .HasForeignKey("TIRIRIT_USER_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tiririt.Data.Entities.WATCH_LIST", b =>
                {
                    b.HasOne("Tiririt.Data.Entities.TIRIRIT_USER", "Ref_TiriritUser")
                        .WithMany()
                        .HasForeignKey("Ref_TiriritUserTIRIRIT_USER_ID");
                });

            modelBuilder.Entity("Tiririt.Data.Entities.WATCH_LIST_STOCK", b =>
                {
                    b.HasOne("Tiririt.Data.Entities.STOCK", "Ref_Stock")
                        .WithMany("Ref_StocksInWatchLists")
                        .HasForeignKey("STOCK_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tiririt.Data.Entities.WATCH_LIST", "Ref_WatchList")
                        .WithMany("Ref_Stocks")
                        .HasForeignKey("WATCH_LIST_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
