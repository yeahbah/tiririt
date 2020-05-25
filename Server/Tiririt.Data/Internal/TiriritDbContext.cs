using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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

        public DbSet<TIRIRIT_USER> TiriritUsers { get; set; }

        public DbSet<POST_HASH_TAG> PostHashTags { get; set; }

        public DbSet<POST_STOCK> PostStocks { get; set; }
        public DbSet<STOCK_EOD> StockEndOfDayData { get; set; }
        public DbSet<STOCK_SECTOR> StockSectors { get; set; }
        public DbSet<STOCK> Stocks { get; set; }
        public DbSet<TIRIRIT_POST> TiriritPosts { get; set; }
        public DbSet<WATCH_LIST_STOCK> WatchListStoks { get; set; }
        public DbSet<WATCH_LIST> WatchLists { get; set; }
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