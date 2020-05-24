using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Tiririt.Data.Internal
{
    public class TiriritDbContext : DbContext
    {
        public static readonly ILoggerFactory _loggerFactory  = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public TiriritDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseLoggerFactory(_loggerFactory)
                .UseMySQL("server=localhost;database=tiriritDb;user=arnold;password=1q2w3e4r");
        }
    }
}