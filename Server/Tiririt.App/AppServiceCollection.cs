using Tiririt.Data;
using Microsoft.Extensions.DependencyInjection;
using Tiririt.App.Internal.Service;
using Tiririt.App.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Tiririt.App
{
    public static class AppServiceCollection
    {
        public static IServiceCollection AddAppServiceCollection(this IServiceCollection services, IWebHostEnvironment env)
        {
            return services                
                .AddDataService(env)
                .AddScoped<IStockService, StockService>()
                .AddScoped<IWatchListService, WatchListService>()
                .AddScoped<IStockSectorService, StockSectorService>()
                .AddScoped<IStockQuoteService, StockQuoteService>()
                .AddScoped<ITiriritPostService, TiriritPostService>();
        }
    }
}