using managementtaskexercice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Persistence.Configurations
{
    public class  MTaskConfiguration:IEntityTypeConfiguration<MTask>
    {
        public void Configure(EntityTypeBuilder<MTask> builder)
        {

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(t => t.Status)
                .IsRequired()
                .HasConversion<string>();
            builder.Property(t => t.DueDate)
                .HasColumnType("date")
                 .IsRequired();
            builder.Property(t => t.Priority)
                .IsRequired();


            builder.HasOne(t => t.User)
                .WithMany(t => t.Tasks)
                .OnDelete(DeleteBehavior.Cascade);

               
        }
    }
}
