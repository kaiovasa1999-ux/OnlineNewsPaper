using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineNewsPaper.Data.Models;
using System.Reflection;

namespace OnlineNewsPaper.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<NewsAd> NewsAd { get; set; }

        public DbSet<NewsCategory> NewsCategories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<SpecificCategory> SpecificCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

    }
}