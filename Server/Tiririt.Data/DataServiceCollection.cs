using Microsoft.EntityFrameworkCore;
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
            return services
                .AddDbContext<TiriritDbContext>(options => {
                    options.UseNpgsql("Host=localhost; Database=TiriritDb; Username=arnold;Password=1q2w3e4r"); })
                .AddScoped<IStockRepository, StockRepository>()
                .AddScoped<IWatchListRepository, WatchListRepository>()
                .AddScoped<IStockSectorRepository, StockSectorRepository>()
                .AddScoped<IStockQuoteRepository, StockQuoteRepository>()
                .AddScoped<ITiriritPostRepository, TiriritPostRepository>();
        }
    }
}