using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Data.Models;

namespace PCStore.DAL.Configurations
{
    public class CountManipulationonfiguration : IEntityTypeConfiguration<CountManipulation>
    {
        public void Configure(EntityTypeBuilder<CountManipulation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Quantity)
                .HasMaxLength(100);

            builder.HasOne(x => x.Manipulation)
                .WithMany(x => x.CountManipulations)
                .HasForeignKey(x => x.ManipulationId);

            builder.HasOne(x => x.Count)
                .WithMany(x => x.CountManipulations)
                .HasForeignKey(x => x.CountId);
        }
    }
}
