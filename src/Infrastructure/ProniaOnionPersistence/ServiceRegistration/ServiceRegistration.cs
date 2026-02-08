using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.src.Application;

namespace ProniaOnion.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
            opt=> opt.UseSqlServer(configuration.GetConnectionString("Default")));
            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IColorRepository,ColorRepository>();

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            return services;    
        }
    }
}


// set as startup project