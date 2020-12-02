using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Security.Principal;
using Tiririt.App;
using Tiririt.Core;
using Tiririt.Core.Identity;
using Tiririt.Data.Entities;
using Tiririt.Data.Internal;
using Tiririt.Web.Controllers.Identity;
using System.Collections.Generic;
using Tiririt.Data;

namespace Tiririt.Web
{
    public class Startup
    {
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
            services
                .AddCoreServices()
                .AddAppServiceCollection();

            services
                .AddIdentity<TIRIRIT_USER, IdentityRole<int>>(config =>
                {
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequiredLength = 4;
                    config.Password.RequireDigit = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireUppercase = false;
                    config.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<TiriritDbContext>()
                .AddClaimsPrincipalFactory<ClaimsFactory>()
                .AddDefaultTokenProviders();

            var builder = services
                .AddIdentityServer(options =>
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

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(
                provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Titos and Titas of Finance API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                            {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            services.AddLocalApiAuthentication();

            services.AddSwaggerGenNewtonsoftSupport();

            services
                .AddGraphQLServer()
                .AddQueryType<Query>();
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

            //app.UseAuthentication();
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
                endpoints.MapGraphQL();
            });
            
        }
    }


}
