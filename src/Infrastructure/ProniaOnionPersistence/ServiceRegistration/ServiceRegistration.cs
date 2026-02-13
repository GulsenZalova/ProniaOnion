using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.src.Application;
using ProniaOnion.src.Domain;

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


            services.AddIdentity<AppUser,IdentityRole>(opt=>
            {
                opt.Password.RequiredLength=8;
                opt.Password.RequireNonAlphanumeric=true;
                opt.User.RequireUniqueEmail=true;

                opt.Lockout.AllowedForNewUsers=true;
                opt.Lockout.DefaultLockoutTimeSpan=TimeSpan.FromMinutes(1);
                opt.Lockout.MaxFailedAccessAttempts=3;

            }
            ).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;    
           
        }
    }
}


// set as startup project