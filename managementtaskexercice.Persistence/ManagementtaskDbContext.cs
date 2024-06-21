using managementtaskexercice.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Persistence
{
    public class ManagementtaskDbContext : IdentityDbContext<User>
    {
        public DbSet<MTask> Tasks { get; set; }
        public ManagementtaskDbContext(DbContextOptions<ManagementtaskDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagementtaskDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
