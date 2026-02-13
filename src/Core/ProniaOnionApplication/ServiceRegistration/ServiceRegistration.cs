using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.src.Application;

namespace ProniaOnion.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
             services.AddAutoMapper(Assembly.GetExecutingAssembly());
             
             services.AddFluentValidationAutoValidation()
             .AddFluentValidationClientsideAdapters()
             .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
             ;
            return services;    
        }
    }
}
