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
    public class NakladniProductsConfiguration : IEntityTypeConfiguration<NakladniProducts>
    {
        public void Configure(EntityTypeBuilder<NakladniProducts> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Quantity);

            builder.Property(x => x.Discount);

            builder.Property(x => x.Price);

            builder.HasOne(x => x.Nakladni)
                .WithMany(x => x.NakladniProducts)
                .HasForeignKey(x => x.NakladnaId);

            builder.HasOne(x => x.Product)
               .WithMany(x => x.NakladniProducts)
               .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.ProductStorage)
                .WithMany(x => x.NakladniProducts)
                .HasForeignKey(x => x.ProductStorageId);
        }
    }
}
