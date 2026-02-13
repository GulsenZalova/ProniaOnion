using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProniaOnion.src.Application;

namespace ProniaOnion.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastuctureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters=new TokenValidationParameters
                {
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,


                    ValidIssuer= configuration["JWT:Issuer"],
                    ValidAudience=configuration["JWT:Audience"],
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:SecretKey"])),
                    LifetimeValidator = (_, expires, key, _) =>
                    {
                        if(key!=null && expires != null)
                        {
                            if (expires.Value > DateTime.Now)
                            {
                                return true;
                            }
                            
                        }
                        return false;
                    }


                };
            });
            services.AddAuthorization();
            return services;
        }
    } 
} 