using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Tiririt.Data.Entities;

namespace Tiririt.Data.Internal
{
    internal class TiriritDbContext : DbContext
    {
        public static readonly ILoggerFactory _loggerFactory  = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public TiriritDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseLoggerFactory(_loggerFactory);                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .HasKey(b => new { b.POST_STOCK_ID, b.TIRIRIT_POST_ID });                
            modelBuilder.Entity<POST_STOCK>()
                .HasOne(ps => ps.Ref_Stock)
                .WithMany(ps => ps.Ref_TiriritPosts)
                .HasForeignKey(ps => ps.STOCK_ID);
            modelBuilder.Entity<POST_STOCK>()
                .HasOne(ps => ps.Ref_TiriritPost)
                .WithMany(ps => ps.Ref_Stocks)
                .HasForeignKey(ps => ps.TIRIRIT_POST_ID);
            
            modelBuilder.Entity<STOCK_SECTOR>()
                .ToTable("stock_sector")
                .HasMany(b => b.Ref_Stocks)
                .WithOne(b => b.Ref_Sector)
                .HasForeignKey(b => b.SECTOR_ID);

            modelBuilder.Entity<STOCK>()   
                .ToTable("stock")
                .HasOne(b => b.Ref_Sector);
            modelBuilder.Entity<STOCK>()
                .HasMany(b => b.Ref_StockQuotes)
                .WithOne(b => b.Ref_Stock)
                .HasForeignKey(b => b.STOCK_ID);

            modelBuilder.Entity<STOCK_QUOTE>()
                .ToTable("stock_quote")
                .HasOne(b => b.Ref_Stock);            

            modelBuilder.Entity<WATCH_LIST>()
                .ToTable("watch_list")
                .HasMany(b => b.Ref_Stocks)
                .WithOne(b => b.Ref_WatchList);

            modelBuilder.Entity<WATCH_LIST_STOCK>()      
                .ToTable("watch_list_stock")          
                .HasOne(b => b.Ref_Stock);

            modelBuilder.Entity<TIRIRIT_USER>()
                .ToTable("tiririt_user")
                .HasMany(u => u.Ref_TiriritPosts)
                .WithOne(u => u.Ref_PostedBy)
                .HasForeignKey(u => u.TIRIRIT_USER_ID);    

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
        public DbSet<STOCK_QUOTE> StockEndOfDayData { get; set; }
        public DbSet<STOCK_SECTOR> StockSectors { get; set; }
        public DbSet<STOCK> Stocks { get; set; }
        public DbSet<TIRIRIT_POST> TiriritPosts { get; set; }
        public DbSet<WATCH_LIST_STOCK> WatchListStoks { get; set; }
        public DbSet<WATCH_LIST> WatchLists { get; set; }
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
            //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyCookingMaster.API/appsettings.json").Build(); 
            var builder = new DbContextOptionsBuilder<TiriritDbContext>(); 
            // var connectionString = configuration.GetConnectionString("DatabaseConnection"); 
            var connectionString = "Host=localhost; Database=TiriritDb; Username=arnold;Password=1q2w3e4r";
            builder.UseNpgsql(connectionString); 
            return new TiriritDbContext(builder.Options); 
        }
    }
}