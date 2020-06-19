using IdentityServer4.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Tiririt.App;
using Tiririt.Web.Models;
using Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore;
using IdentityModel;
using Tiririt.Core.Identity;
using Tiririt.Web.Controllers.Identity;
using Tiririt.Data.Internal;
using Microsoft.AspNetCore.Identity;
using Tiririt.Data.Entities;

namespace Tiririt.Web
{
    public class Startup
    {

        //private string corsSpecificOrigins = "_corsSpecificOrigins";
        //private readonly ILoggerFactory loggerFactory;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });
            services.AddControllersWithViews()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                });
            //services.AddRazorPages();            

            services.AddAppServiceCollection();

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
                //.AddClaimsPrincipalFactory<ClaimsFactory>()
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

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim(JwtClaimTypes.Role, Roles.StandardUser));
                options.AddPolicy("Admin", policy => policy.RequireClaim(JwtClaimTypes.Role, Roles.Admin));                
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Titos and Titas of Finance API",
                    Version = "v1"
                });
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                // prod stuff
                //app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();            

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapDefaultControllerRoute();
            });
            
        }
    }


}
