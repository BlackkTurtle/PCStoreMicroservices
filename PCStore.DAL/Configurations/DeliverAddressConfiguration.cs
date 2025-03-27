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
    public class DeliverAddressConfiguration : IEntityTypeConfiguration<DeliverAddress>
    {
        public void Configure(EntityTypeBuilder<DeliverAddress> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Country)
                .HasMaxLength(30);

            builder.Property(x => x.City)
                .HasMaxLength(30);

            builder.Property(x => x.FullAddress)
                .HasMaxLength(150);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.DeliverAddress)
                .HasForeignKey(x => x.DeliverAddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DeliverOption)
                .WithMany(x => x.DeliverAddresses)
                .HasForeignKey(x => x.DeliverOptionId);
        }
    }
}
