using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sicom.Dominio.Context;
using Sicom.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Internal;

namespace Sicom.WebApi.App_Config
{
    public static class Database
    {
        public static void InitializeSpfDatabase(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (environment.IsDevelopment())
                {
                    context.Database.Migrate();

                    context.SaveChanges();

                }
            }
        }
    }

}
