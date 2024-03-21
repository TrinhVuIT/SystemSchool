using Microsoft.EntityFrameworkCore;
using NS.Core.Models;

namespace NS.Core.API.Extensions
{
    public static class DbMigrationExtension
    {
        public static void UseDbMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }
        }

        public static void UseDataSeeding(this IApplicationBuilder app, bool isDevelopment = false)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                // private readonly IConfiguration _configuration
                var config = serviceScope.ServiceProvider.GetRequiredService<IConfiguration>();
                DataSeeding.ProductionSeed(context, config);
                DataSeeding.DevelopementSeed(context, config);
                if (isDevelopment)
                {
                }
                else
                {
                }
            }
        }
    }
}
