using System;
using ControleEstoque.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ControleEstoque.Areas.Identity.IdentityHostingStartup))]
namespace ControleEstoque.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ControleEstoqueContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ControleEstoqueContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<ControleEstoqueContext>();
            });
        }
    }
}