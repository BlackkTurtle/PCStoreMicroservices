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
    public class NakladnaTypeConfiguration : IEntityTypeConfiguration<NakladnaType>
    {
        public void Configure(EntityTypeBuilder<NakladnaType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.HasMany(x => x.Nakladnis)
                .WithOne(x => x.NakladnaType)
                .HasForeignKey(x => x.NakladnaTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
