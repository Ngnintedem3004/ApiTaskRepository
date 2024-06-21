using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Application.Contracts.Users.Login;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Application.Validators;
using managementtaskexercice.Authentication.Token;
using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Authentication.Extensions.Authentication
{
    public static  class AuthenticationExtension
    {
        public static IServiceCollection AddAuthenticationExtension(this IServiceCollection Services)
        {
            Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ManagementtaskDbContext>().AddDefaultTokenProviders();
            Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;

            });
            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:7255",
                        ValidAudience = "https://localhost:7255",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vanleroy53@gmail.comvanleroy53@gmail.comvanleroy53@gmail.com"))
                    };
                }
            
            );

            Services.AddScoped<IAuthenticate<Login>,Authenticate>();
            Services.AddScoped<IAsyncAddUserIdClaim<User>,AddUserIdClaim>();
            Services.AddScoped<IVerifyUserIdClaim, VerifyUserIdClaim>();
            Services.AddScoped<IGenerateToken, GenerateToken>();


            return Services;
        }



        
    }
}
