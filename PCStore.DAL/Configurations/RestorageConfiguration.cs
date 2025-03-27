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
    public class RestorageConfiguration : IEntityTypeConfiguration<Restorages>
    {
        public void Configure(EntityTypeBuilder<Restorages> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.RestorageDate);

            builder.HasMany(x => x.ProductRestorages)
                .WithOne(x => x.Restorages)
                .HasForeignKey(x => x.RestorageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
