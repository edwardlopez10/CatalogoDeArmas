using System;
using CatalogoDeArmas.Areas.Identity.Data;
using CatalogoDeArmas.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CatalogoDeArmas.Areas.Identity.IdentityHostingStartup))]
namespace CatalogoDeArmas.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CatalogoDeArmasContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CatalogoDeArmasContextConnection")));

                services.AddDefaultIdentity<CatalogoDeArmasUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                    .AddEntityFrameworkStores<CatalogoDeArmasContext>();
            });
        }
    }
}