using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Tiririt.Core.Enums;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal.Entities;

namespace Tiririt.Data.Internal
{
    public class TiriritDbContext : IdentityDbContext<TIRIRIT_USER, IdentityRole<int>, int> //IPersistedGrantDbContext
    {
        public static readonly ILoggerFactory _loggerFactory  = LoggerFactory.Create(
            builder => { 
                builder.AddConsole();
                builder.AddDebug();
            });
        private readonly IOptions<OperationalStoreOptions> operationalStoreOptions;

        public TiriritDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options)
        {
            this.operationalStoreOptions = operationalStoreOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //base.OnConfiguring(builder);
            //builder
            //    .UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigurePersistedGrantContext(this.operationalStoreOptions.Value);

            // a user can have many posts
            modelBuilder.Entity<TIRIRIT_USER>()
                .ToTable("tiririt_user");

            modelBuilder.Entity<TIRIRIT_USER>()
                .HasMany(u => u.Ref_TiriritPosts)
                .WithOne(u => u.Ref_PostedBy)
                .HasForeignKey(u => u.TIRIRIT_USER_ID);            

            //modelBuilder.Entity<TIRIRIT_USER>()
            //    .HasAlternateKey(u => u.TIRIRIT_USER_ID);

            // user can have many watch lists
            modelBuilder.Entity<TIRIRIT_USER>()
                .HasMany(b => b.Ref_WatchLists)
                .WithOne(b => b.Ref_TiriritUser)
                .HasForeignKey(b => b.TIRIRIT_USER_ID);            

            modelBuilder.Entity<HASH_TAG>()
                .ToTable("hash_tag");
                
            // many-to-many POST-HASH-TAG            
            modelBuilder.Entity<POST_HASH_TAG>()
                .ToTable("post_hash_tag")
                .HasKey(ph => new { ph.TIRIRIT_POST_ID, ph.HASH_TAG_ID});
            modelBuilder.Entity<POST_HASH_TAG>()
                .HasOne(ph => ph.Ref_HashTag)
                .WithMany(ph => ph.Ref_TiriritPosts)
                .HasForeignKey(ph => ph.HASH_TAG_ID);
            modelBuilder.Entity<POST_HASH_TAG>()
                .HasOne(ph => ph.Ref_TiriritPost)
                .WithMany(ph => ph.Ref_HashTags)
                .HasForeignKey(ph => ph.TIRIRIT_POST_ID);
            
            modelBuilder.Entity<TIRIRIT_POST>()
                .ToTable("tiririt_post")
                .HasOne(p => p.Ref_TiriritPost)
                .WithMany(p => p.Ref_Responses)
                .HasForeignKey(p => p.RESPONSE_TO_POST_ID);                        
                
            // many-to-many POST-STOCK
            modelBuilder.Entity<POST_STOCK>()
                .ToTable("post_stock")
                .HasKey(b => new { b.STOCK_ID, b.TIRIRIT_POST_ID });                
            modelBuilder.Entity<POST_STOCK>()
                .HasOne(ps => ps.Ref_Stock)
                .WithMany(ps => ps.Ref_TiriritPosts)
                .HasForeignKey(ps => ps.STOCK_ID);
            modelBuilder.Entity<POST_STOCK>()
                .HasOne(ps => ps.Ref_TiriritPost)
                .WithMany(ps => ps.Ref_Stocks)
                .HasForeignKey(ps => ps.TIRIRIT_POST_ID);

            // many-to-many post-user-mentions
            modelBuilder.Entity<MENTION>()
                .ToTable("mention")
                .HasKey(m => new { m.TIRIRIT_POST_ID, m.TIRIRIT_USER_ID });
            modelBuilder.Entity<MENTION>()
                .HasOne(post => post.Ref_TiriritPost)
                .WithMany(post => post.Ref_MentionUsers)
                .HasForeignKey(post => post.TIRIRIT_POST_ID);
            modelBuilder.Entity<MENTION>()
                .HasOne(user => user.Ref_TiriritUser)
                .WithMany(user => user.Ref_MentionedInPosts)
                .HasForeignKey(user => user.TIRIRIT_USER_ID);

            modelBuilder.Entity<STOCK_SECTOR>()
                .ToTable("stock_sector")
                .HasMany(b => b.Ref_Stocks)
                .WithOne(b => b.Ref_Sector)
                .HasForeignKey(b => b.SECTOR_ID);
            modelBuilder.Entity<STOCK_SECTOR>()
                .HasAlternateKey(b => b.SECTOR_NAME);

            // a stock can only belong to 1 sector
            modelBuilder.Entity<STOCK>()   
                .ToTable("stock")                
                .HasOne(b => b.Ref_Sector);
            modelBuilder.Entity<STOCK>()
                .HasAlternateKey(b => b.SYMBOL);
            // a stock can have many stock quotes
            modelBuilder.Entity<STOCK>()
                .HasMany(b => b.Ref_StockQuotes)
                .WithOne(b => b.Ref_Stock)
                .HasForeignKey(b => b.STOCK_ID);
            
            // stock can be in many watch lists
            modelBuilder.Entity<STOCK>()
                .HasMany(b => b.Ref_StocksInWatchLists)
                .WithOne(b => b.Ref_Stock)
                .HasForeignKey(b => b.STOCK_ID);

            modelBuilder.Entity<STOCK_QUOTE>()
                .ToTable("stock_quote")
                .HasOne(b => b.Ref_Stock);            

            // a watch list can have many stocks
            modelBuilder.Entity<WATCH_LIST>()
                .ToTable("watch_list")
                .HasMany(b => b.Ref_Stocks)
                .WithOne(b => b.Ref_WatchList)
                .HasForeignKey(b => b.WATCH_LIST_ID);

            modelBuilder.Entity<WATCH_LIST_STOCK>()      
                .ToTable("watch_list_stock")          
                .HasOne(b => b.Ref_Stock);
            
            modelBuilder.Entity<BULL_BEAR_LEVEL_CODE>()
                .ToTable("bull_bear_level_code")
                .HasAlternateKey("BULL_BEAR_LEVEL_CD");
            modelBuilder.Entity<BULL_BEAR_LEVEL_CODE>()
                .HasMany(b => b.Ref_TiriritPosts)
                .WithOne(b => b.Ref_BullBearLevel)
                .HasForeignKey(b => b.BULL_BEAR_LEVEL_CODE_ID);
                              
            modelBuilder.Entity<BULL_BEAR_LEVEL_CODE>()
                .HasData(
                    Enum.GetValues(typeof(BullBearLevel))
                        .Cast<BullBearLevel>()                        
                        .Select(e => new BULL_BEAR_LEVEL_CODE{
                            BULL_BEAR_LEVEL_CD = e.ToString(),
                            BULL_BEAR_LEVEL_CODE_ID = (int)e
                        })
                );

            // many-to-many post users likes/dislikes
            modelBuilder.Entity<LIKE_DISLIKE_POST>()
                .ToTable("like_dislike_post")
                .HasKey(l => new { l.TIRIRIT_USER_ID, l.TIRIRIT_POST_ID });
            modelBuilder.Entity<LIKE_DISLIKE_POST>()
                .HasOne(l => l.Ref_TiriritUser)
                .WithMany(l => l.Ref_LikeDislikePosts)
                .HasForeignKey(l => l.TIRIRIT_USER_ID);
            modelBuilder.Entity<LIKE_DISLIKE_POST>()
                .HasOne(l => l.Ref_TiriritPost)
                .WithMany(l => l.Ref_LikeDislikeByUsers)
                .HasForeignKey(l => l.TIRIRIT_POST_ID);


            foreach(var entity in modelBuilder.Model.GetEntityTypes())        
            {
                // Replace table names
                entity.SetTableName(entity.GetTableName().ToSnakeCase());

                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToSnakeCase());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.PrincipalKey.SetName(key.PrincipalKey.GetName().ToSnakeCase());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(index.GetName().ToSnakeCase());
                }
            }
        }        

        public DbSet<TIRIRIT_USER> TiriritUsers { get; set; }

        public DbSet<POST_HASH_TAG> PostHashTags { get; set; }

        public DbSet<POST_STOCK> PostStocks { get; set; }
        public DbSet<STOCK_QUOTE> StockQuotes { get; set; }
        public DbSet<STOCK_SECTOR> StockSectors { get; set; }
        public DbSet<STOCK> Stocks { get; set; }
        public DbSet<TIRIRIT_POST> TiriritPosts { get; set; }
        public DbSet<WATCH_LIST_STOCK> WatchListStocks { get; set; }
        public DbSet<WATCH_LIST> WatchLists { get; set; }

        public DbSet<BULL_BEAR_LEVEL_CODE> BullBearLevelCode { get; set; }

        public DbSet<LIKE_DISLIKE_POST> LikeDislikePost { get; set; }

        public DbSet<HASH_TAG> HashTags { get; set; }

        public DbSet<MENTION> Mentions { get; set; }
        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
    }

    internal static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }

    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TiriritDbContext>
    {
        public TiriritDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "\\connectionStrings.json")
                .AddUserSecrets("8c724486-0e01-4d42-bfff-aeda2705bfc7")                
                .Build(); 

            var builder = new DbContextOptionsBuilder<TiriritDbContext>(); 
            
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseNpgsql(connectionString);
            
            return new TiriritDbContext(builder.Options, Options.Create(new OperationalStoreOptions())); 
        }
    }
}