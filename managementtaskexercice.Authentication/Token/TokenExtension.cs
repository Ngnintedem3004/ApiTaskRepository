using managementtaskexercice.Application.Contracts.Users.Login;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Authentication.Token
{
    public static  class TokenExtension
    {
        public static IServiceCollection AddToken(this IServiceCollection services)
        {
            services.AddScoped<IGenerateToken, GenerateToken>();
            return services;
            
        }
    }
}
