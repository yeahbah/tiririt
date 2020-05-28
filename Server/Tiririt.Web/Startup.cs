using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tiririt.App;

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
            services.AddControllers()
                .AddJsonOptions(options => {
                    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
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
            
            services.AddAppServiceCollection();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // prod stuff
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions() {
                OnPrepareResponse = (context) => {
                    context.Context.Response.Headers["Cache-Control"] = Configuration["StaticFiles:Headers:Cache-Control"];
                    context.Context.Response.Headers["Pragma"] = Configuration["StaticFiles:Headers:Pragma"];
                    context.Context.Response.Headers["Expires"] = Configuration["StaticFiles:Headers:Expires"];
                }
            });            

            app.UseRouting();            

            app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
