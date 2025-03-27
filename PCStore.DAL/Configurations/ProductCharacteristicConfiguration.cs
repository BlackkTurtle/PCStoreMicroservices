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
    public class ProductCharacteristicConfiguration : IEntityTypeConfiguration<ProductCharacteristics>
    {
        public void Configure(EntityTypeBuilder<ProductCharacteristics> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(100);

            builder.Property(x => x.Linkable);

            builder.HasOne(x => x.Characteristic)
                .WithMany(x => x.ProductCharacteristics)
                .HasForeignKey(x => x.CharacteristicId);

            builder.HasOne(x => x.Product)
               .WithMany(x => x.ProductCharacteristics)
               .HasForeignKey(x => x.ProductId);
        }
    }
}
