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
    public class NakladniConfiguration : IEntityTypeConfiguration<Nakladni>
    {
        public void Configure(EntityTypeBuilder<Nakladni> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreationDate);

            builder.Property(x => x.Discount);

            builder.HasMany(x => x.Payments)
                .WithOne(x => x.Nakladni)
                .HasForeignKey(x => x.NakladnaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.NakladniProducts)
                .WithOne(x => x.Nakladni)
                .HasForeignKey(x => x.NakladnaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.NakladnaType)
                .WithMany(x => x.Nakladnis)
                .HasForeignKey(x => x.NakladnaTypeId);

            builder.HasOne(x => x.Contragent)
               .WithMany(x => x.Nakladnis)
               .HasForeignKey(x => x.ContragentId);

            builder.HasOne(x => x.Order)
                .WithOne(x => x.Nakladna)
                .HasForeignKey<Order>(x => x.NakladnaId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
