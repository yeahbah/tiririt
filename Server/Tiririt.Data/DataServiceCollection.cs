using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal;
using Tiririt.Data.Internal.Service;
using Tiririt.Data.Service;

namespace Tiririt.Data
{
    public static class DataServiceCollection 
    {
        public static IServiceCollection AddDataService(this IServiceCollection services, IWebHostEnvironment env) 
        {
            // TODO move connection string to connectionStrings.json
            var config = new ConfigurationBuilder()
                //.SetBasePath(env.WebRootPath)
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
                 .AddScoped<IHashTagRepository, HashTagRepository>();

            services.AddIdentity<TIRIRIT_USER, IdentityRole<int>>(config =>
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

            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
                .AddInMemoryApiResources(IdentityServerConfig.Apis)
                .AddInMemoryClients(IdentityServerConfig.Clients)
                .AddAspNetIdentity<TIRIRIT_USER>();

            builder.AddDeveloperSigningCredential();

            return services;
        }
    }    
}