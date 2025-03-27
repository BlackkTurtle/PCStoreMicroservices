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
    public class CountOperationConfiguration : IEntityTypeConfiguration<CountOperation>
    {
        public void Configure(EntityTypeBuilder<CountOperation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreationDate);

            builder.Property(x=>x.Quantity);

            builder.Property(x=>x.Description).HasMaxLength(500);

            builder.HasOne(x => x.FromCount)
                .WithMany(x => x.FromCountOperations)
                .HasForeignKey(x => x.FromCountId);

            builder.HasOne(x => x.ToCount)
                .WithMany(x => x.ToCountOperations)
                .HasForeignKey(x => x.ToCountId);
        }
    }
}
