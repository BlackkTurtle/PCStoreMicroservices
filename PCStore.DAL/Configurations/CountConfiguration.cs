using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Data.Models;

namespace PCStore.DAL.Configurations
{
    public class CountConfiguration : IEntityTypeConfiguration<Count>
    {
        public void Configure(EntityTypeBuilder<Count> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.Quantity);

            builder.HasMany(x => x.Payments)
                .WithOne(x => x.Count)
                .HasForeignKey(x => x.CountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.FromCountOperations)
                .WithOne(x => x.FromCount)
                .HasForeignKey(x => x.FromCountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ToCountOperations)
                .WithOne(x => x.ToCount)
                .HasForeignKey(x => x.ToCountId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CountManipulations)
                .WithOne(x => x.Count)
                .HasForeignKey(x => x.CountId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
