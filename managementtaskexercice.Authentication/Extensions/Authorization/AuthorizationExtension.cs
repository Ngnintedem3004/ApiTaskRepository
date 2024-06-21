using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Authentication.Extensions.Authorization
{
    public static  class AuthorizationExtension
    {

        public static IServiceCollection Authorization(this IServiceCollection services) {

            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserOnly", policy => policy.RequireClaim("UserId"));


            });

            return services;
        }
    }
}
