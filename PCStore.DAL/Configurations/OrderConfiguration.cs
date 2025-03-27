using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                .HasMaxLength(50);

            builder.Property(x => x.FirstName)
                .HasMaxLength(30);

            builder.Property(x => x.LastName)
                .HasMaxLength(30);

            builder.Property(x => x.FatherName)
                .HasMaxLength(30);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(13);

            builder.Property(x => x.CreatedDate);

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.HasOne(x => x.DeliverAddress)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.DeliverAddressId);

            builder.HasOne(x => x.Status)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.StatusId);

            builder.HasOne(x => x.PaymentType)
               .WithMany(x => x.Orders)
               .HasForeignKey(x => x.PaymentTypeId);

            builder.HasOne(x => x.Nakladna)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.NakladnaId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
