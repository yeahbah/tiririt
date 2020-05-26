using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tiririt.Data.Internal;
using Tiririt.Data.Internal.Service;
using Tiririt.Data.Service;

namespace Tiririt.Data
{
    public static class ServiceCollection 
    {
        public static IServiceCollection AddDataService(this IServiceCollection services) 
        {
            return services
                .AddDbContext<TiriritDbContext>(options => {
                    options.UseNpgsql("Host=localhost; Database=TiriritDb; Username=arnold;Password=1q2w3e4r"); })
                .AddTransient<IStockRepository, StockRepository>()
                .AddTransient<IWatchListRepository, WatchListRepository>()
                .AddTransient<IStockSectorRepository, StockSectorRepository>()
                .AddTransient<IStockQuoteRepository, StockQuoteRepository>();
        }
    }
}