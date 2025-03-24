using DemoBlazorServerRecipe.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoBlazorServerRecipe.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Recipe> Recipes { get; set; } = default!;
        public DbSet<Step> Procedures { get; set; } = default!;
        public DbSet<Country> Countries { get; set; } = default!;
    }
}
