using CookBook.Model;
using CookBook.Model.Enums;
using CookBooks.Model;
using Microsoft.EntityFrameworkCore;

namespace CookBooks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }

        public DbSet<Instructions> Instructions { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        

    }
}
