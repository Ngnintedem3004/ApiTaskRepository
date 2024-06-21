using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;


namespace managementtaskexercice.Authentication.Extensions.Session
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {

             session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value==null ? default : JsonSerializer.Deserialize<T>(value);
        }
        public static IServiceCollection Session(this IServiceCollection services)
        {
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
        
    }
}
