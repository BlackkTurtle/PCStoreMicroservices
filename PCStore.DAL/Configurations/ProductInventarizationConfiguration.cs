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
    public class ProductInventarizationConfiguration : IEntityTypeConfiguration<ProductInventarization>
    {
        public void Configure(EntityTypeBuilder<ProductInventarization> builder)
        {
            builder.HasKey(x => new {x.InventarizationId,x.ProductStorageId});

            builder.Property(x => x.QuantityDiff);

            builder.HasOne(x => x.Inventarizations)
                .WithMany(x => x.ProductInventarizations)
                .HasForeignKey(x => x.InventarizationId);

            builder.HasOne(x => x.ProductsStorage)
               .WithMany(x => x.ProductInventarizations)
               .HasForeignKey(x => x.ProductStorageId);
        }
    }
}
