using Tiririt.Data;
using Microsoft.Extensions.DependencyInjection;
using Tiririt.App.Internal.Service;
using Tiririt.App.Service;

namespace Tiririt.App
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddAppServiceCollection(this IServiceCollection services)
        {
            return services                
                .AddDataService()
                .AddScoped<IStockService, StockService>()
                .AddScoped<IWatchListService, WatchListService>()
                .AddScoped<IStockSectorService, StockSectorService>()
                .AddScoped<IStockQuoteService, StockQuoteService>()
                .AddScoped<ITiriritPostService, TiriritPostService>();
        }
    }
}