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
    public class ProductRestorageConfiguration : IEntityTypeConfiguration<ProductRestorage>
    {
        public void Configure(EntityTypeBuilder<ProductRestorage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Quantity);

            builder.HasOne(x => x.Restorages)
                .WithMany(x => x.ProductRestorages)
                .HasForeignKey(x => x.RestorageId);

            builder.HasOne(x => x.ProductStorage)
               .WithMany(x => x.ProductRestorages)
               .HasForeignKey(x => x.ProductStorageId);

            builder.HasOne(x => x.FromStorage)
                .WithMany(x => x.FromProductRestorage)
                .HasForeignKey(x => x.FromStorageId);

            builder.HasOne(x => x.ToStorage)
                .WithMany(x => x.ToProductRestorage)
                .HasForeignKey(x => x.ToStorageId);
        }
    }
}
