using System;
using Dientes_Sanos_Core_MVC.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Dientes_Sanos_Core_MVC.Areas.Identity.IdentityHostingStartup))]
namespace Dientes_Sanos_Core_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Dientes_Sanos_Core_MVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Conexion_azure_asp")));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<Dientes_Sanos_Core_MVCContext>();
            });
        }
    }
}