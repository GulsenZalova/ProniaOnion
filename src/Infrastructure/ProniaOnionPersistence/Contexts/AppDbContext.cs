using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.src.Domain;

namespace ProniaOnion.Persistence
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext >options) : base(options){}
        public DbSet<Category> Categories { get; set;   }
        public DbSet<Product> Products { get; set;}
        public DbSet<Color> Colorss { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.ApplyConfiguration(new ProductConfiguration());
            // modelBuilder.ApplyConfiguration(new ColorConfiguration());
            // modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            // modelBuilder.ApplyConfiguration(new ProductColorConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}