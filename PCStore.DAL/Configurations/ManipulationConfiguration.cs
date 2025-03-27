using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Configurations
{
    public class ManipulationConfiguration : IEntityTypeConfiguration<Manipulation>
    {
        public void Configure(EntityTypeBuilder<Manipulation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.Operation);

            builder.HasMany(x => x.CountManipulations)
                .WithOne(x => x.Manipulation)
                .HasForeignKey(x => x.ManipulationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
