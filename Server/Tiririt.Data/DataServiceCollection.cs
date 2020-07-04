using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tiririt.Data.Internal;
using Tiririt.Data.Internal.Service;
using Tiririt.Data.Service;

namespace Tiririt.Data
{
    public static class DataServiceCollection 
    {
        public static IServiceCollection AddDataService(this IServiceCollection services) 
        {
            var config = new ConfigurationBuilder()                
                .AddJsonFile("connectionStrings.json", false)
                .AddUserSecrets("8c724486-0e01-4d42-bfff-aeda2705bfc7")
                .Build();

            services
                 .AddDbContext<TiriritDbContext>(options =>
                 {
                     var connectionString = config.GetConnectionString("DefaultConnection");
                     options.UseNpgsql(connectionString);
                 })

                 .AddScoped<IStockRepository, StockRepository>()
                 .AddScoped<IWatchListRepository, WatchListRepository>()
                 .AddScoped<IStockSectorRepository, StockSectorRepository>()
                 .AddScoped<IStockQuoteRepository, StockQuoteRepository>()
                 .AddScoped<ITiriritPostRepository, TiriritPostRepository>()
                 .AddScoped<IHashTagRepository, HashTagRepository>()
                 .AddScoped<IFeedRepository, FeedRepository>()
                 .AddScoped<IMentionRepository, MentionRepository>();

            return services;
        }
    }    
}