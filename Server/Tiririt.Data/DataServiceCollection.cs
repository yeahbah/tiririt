using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
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
           // TODO move connection string to connectionStrings.json
           services
                .AddDbContext<TiriritDbContext>(options => {
                    options.UseNpgsql("Host=localhost; Database=TiriritDb; Username=arnold;Password=1q2w3e4r"); 
                })

                .AddScoped<IStockRepository, StockRepository>()
                .AddScoped<IWatchListRepository, WatchListRepository>()
                .AddScoped<IStockSectorRepository, StockSectorRepository>()
                .AddScoped<IStockQuoteRepository, StockQuoteRepository>()
                .AddScoped<ITiriritPostRepository, TiriritPostRepository>()
                .AddScoped<IHashTagRepository, HashTagRepository>();

            services
                .AddDefaultIdentity<Tiririt.Data.Entities.TIRIRIT_USER>(config =>
                {
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequiredLength = 4;
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireUppercase = false;
                    config.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<TiriritDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}