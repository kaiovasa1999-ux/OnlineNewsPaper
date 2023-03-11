using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data;

namespace OnlineNewsPaper.DatabasePreparor
{
    public static class DataPreparor
    {
        public static IApplicationBuilder Preparo(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedService.ServiceProvider;
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

            db.Database.Migrate();

            return app;
        }

    }
}
