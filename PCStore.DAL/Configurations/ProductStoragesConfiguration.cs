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
    public class ProductStoragesConfiguration : IEntityTypeConfiguration<ProductStorages>
    {
        public void Configure(EntityTypeBuilder<ProductStorages> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Quantity);


            builder.HasMany(x => x.ProductInventarizations)
                .WithOne(x => x.ProductsStorage)
                .HasForeignKey(x => x.ProductStorageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.NakladniProducts)
                .WithOne(x => x.ProductStorage)
                .HasForeignKey(x => x.ProductStorageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ProductRestorages)
                .WithOne(x => x.ProductStorage)
                .HasForeignKey(x => x.ProductStorageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductStorages)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Storage)
               .WithMany(x => x.ProductStorages)
               .HasForeignKey(x => x.StorageId);
        }
    }
}
