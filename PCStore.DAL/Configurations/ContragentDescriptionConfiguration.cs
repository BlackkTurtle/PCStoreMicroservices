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
    public class ContragentDescriptionConfiguration : IEntityTypeConfiguration<ContragentDescription>
    {
        public void Configure(EntityTypeBuilder<ContragentDescription> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasMaxLength(200);

            builder.HasOne(x => x.Contragent)
                .WithMany(x => x.ContragentDescriptions)
                .HasForeignKey(x => x.ContragentId);
        }
    }
}
