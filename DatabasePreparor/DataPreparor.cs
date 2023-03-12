using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineNewsPaper.Data;
using OnlineNewsPaper.Data.Models;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace OnlineNewsPaper.DatabasePreparor
{
    public static class DataPreparor
    {
        public static IApplicationBuilder Preparor(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();
            var serviceProvider = scopedService.ServiceProvider;
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

            db.Database.Migrate();

            if (!db.NewsAdViaCategories.Any())
            {
                DataSeeder(db);
            }

            return app;
        }

        public static void DataSeeder(ApplicationDbContext db)
        {
            var newsCategories = new List<NewsCategory>
            {
                new NewsCategory{Name = "WORLD",Description="World News"},
                new NewsCategory{Name = "US POLITICS",Description="Trends about american politics"},
                new NewsCategory{Name = "BUSINESS && ICONOMICS",Description="New economics and business trends, that will going to be trendy"},
                new NewsCategory{Name = "HEALTH",Description="Health and diets"},
                new NewsCategory{Name = "SPORTS",Description="Was sports news"},
                new NewsCategory{Name = "STYLE",Description="Fashion and style"},
                new NewsCategory{Name = "TECH",Description="Аll about technology"},
            };

            foreach (var item in newsCategories)
            {
                db.NewsCategories.Add(item);
            }

            var specificCAtegories = new List<List<SpecificCategory>>
            {
                new List<SpecificCategory>
                {
                    new SpecificCategory { NewsCategoryId = 1, Name ="Africa"},
                    new SpecificCategory { NewsCategoryId = 1, Name ="Asia"},
                    new SpecificCategory { NewsCategoryId = 1, Name ="Australia"},
                    new SpecificCategory { NewsCategoryId = 1, Name ="China"},
                    new SpecificCategory { NewsCategoryId = 1, Name ="Europe"},
                    new SpecificCategory { NewsCategoryId = 1, Name ="India"},
                    new SpecificCategory { NewsCategoryId = 1, Name ="Middle East"},
                    new SpecificCategory { NewsCategoryId = 1, Name ="United Kingdom"},
                },
                new List<SpecificCategory>
                {
                    new SpecificCategory{NewsCategoryId = 2, Name ="The Biden Presidency"},
                    new SpecificCategory{NewsCategoryId = 2, Name ="Facts First"},
                    new SpecificCategory{NewsCategoryId = 2, Name ="US Elections"},
                },
                new List<SpecificCategory>
                {
                    new SpecificCategory{NewsCategoryId = 3, Name ="Tech"},
                    new SpecificCategory{NewsCategoryId = 3, Name ="Media"},
                    new SpecificCategory{NewsCategoryId = 3, Name ="Success"},
                    new SpecificCategory{NewsCategoryId = 3, Name ="Perspectives"},
                },
                new List<SpecificCategory>
                {
                    new SpecificCategory{NewsCategoryId = 4, Name="Life, But Better"},
                    new SpecificCategory{NewsCategoryId = 4, Name="Fitness"},
                    new SpecificCategory{NewsCategoryId = 4, Name="Food"},
                    new SpecificCategory{NewsCategoryId = 4, Name="Sleep"},
                    new SpecificCategory{NewsCategoryId = 4, Name="Mindfulness"},
                    new SpecificCategory{NewsCategoryId = 4, Name="Relationships"},
                },
                new List<SpecificCategory>
                {
                    new SpecificCategory{NewsCategoryId = 5, Name ="Football"},
                    new SpecificCategory{NewsCategoryId = 5, Name ="Tennis"},
                    new SpecificCategory{NewsCategoryId = 5, Name ="Golf"},
                    new SpecificCategory{NewsCategoryId = 5, Name ="Motorsport"},
                    new SpecificCategory{NewsCategoryId = 5, Name ="US Sports"},
                    new SpecificCategory{NewsCategoryId = 5, Name ="Climbing"},
                    new SpecificCategory{NewsCategoryId = 5, Name ="Formula E"},
                    new SpecificCategory{NewsCategoryId = 5, Name ="Esports"},
                    new SpecificCategory{NewsCategoryId = 5, Name ="Hockey"},
                },
                new List<SpecificCategory>
                {
                    new SpecificCategory {NewsCategoryId = 6, Name ="Arts"},
                    new SpecificCategory {NewsCategoryId = 6, Name ="Design"},
                    new SpecificCategory {NewsCategoryId = 6, Name ="Fashion"},
                    new SpecificCategory {NewsCategoryId = 6, Name ="Architecture"},
                    new SpecificCategory {NewsCategoryId = 6, Name ="Beauty"},
                    new SpecificCategory {NewsCategoryId = 6, Name ="Luxury"},
                    new SpecificCategory {NewsCategoryId = 6, Name ="Video"},
                },
                new List<SpecificCategory>
                {
                    new SpecificCategory{NewsCategoryId = 7, Name = "Innovate" },
                    new SpecificCategory{NewsCategoryId = 7, Name = "Gadget" },
                    new SpecificCategory{NewsCategoryId = 7, Name = "Foreseeable Future" },
                    new SpecificCategory{NewsCategoryId = 7, Name = "Mission: Ahead" },
                    new SpecificCategory{NewsCategoryId = 7, Name = "Upstarts" },
                    new SpecificCategory{NewsCategoryId = 7, Name = "Work Transformed" },
                    new SpecificCategory{NewsCategoryId = 7, Name = "Innovative Cities" },
                }
            };

            foreach (var lists in specificCAtegories)
            {
                foreach (var item in lists)
                {
                    db.SpecificCategories.Add(item);
                }
            }

            db.SaveChanges();
        }

    }
}
