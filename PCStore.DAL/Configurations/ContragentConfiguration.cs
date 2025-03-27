using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Data.Models;

namespace PCStore.DAL.Configurations
{
    public class ContragentConfiguration : IEntityTypeConfiguration<Contragent>
    {
        public void Configure(EntityTypeBuilder<Contragent> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.HasMany(x=>x.ContragentDescriptions)
                .WithOne(x=>x.Contragent)
                .HasForeignKey(x=>x.ContragentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Nakladnis)
                .WithOne(x => x.Contragent)
                .HasForeignKey(x => x.ContragentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
