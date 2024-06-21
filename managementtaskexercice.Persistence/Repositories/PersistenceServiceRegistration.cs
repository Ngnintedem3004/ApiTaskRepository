using managementtaskexercice.Application.Contracts.Persistence;
using managementtaskexercice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Persistence.Repositories
{
    public static  class PersistenceServiceRegistrationed
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection Services,IConfiguration Configuration)
        {
           //Services.AddDbContext<ManagementtaskDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("connectionString")));
           //Services.AddScoped<IAsyncRepository<MTask>,BaseRepository<MTask>>();
           Services.AddScoped< IAsyncTaskRepository,MtaskRepository>();
           Services.AddScoped<IAsyncUserRepository, UserRepository>();
            return Services;
        }

        public static async Task InitializeDb(this IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ManagementtaskDbContext>();
            await dbContext.Database.MigrateAsync();
            var logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>()
                                        .CreateLogger("DB initialiser");
            logger.LogInformation(7, "Database work properly");

        }
    }
}
