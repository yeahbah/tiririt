using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tiririt2.Web.Areas.Identity.Data;
using Tiririt2.Web.Data;

[assembly: HostingStartup(typeof(Tiririt2.Web.Areas.Identity.IdentityHostingStartup))]
namespace Tiririt2.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Tiririt2WebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Tiririt2WebContextConnection")));

                services.AddDefaultIdentity<Tiririt2WebUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Tiririt2WebContext>();
            });
        }
    }
}