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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Amount);

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.HasOne(x => x.Nakladni)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.NakladnaId);

            builder.HasOne(x => x.Count)
               .WithMany(x => x.Payments)
               .HasForeignKey(x => x.CountId);

            builder.HasOne(x => x.PaymentType)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.PaymentTypeId);
        }
    }
}
