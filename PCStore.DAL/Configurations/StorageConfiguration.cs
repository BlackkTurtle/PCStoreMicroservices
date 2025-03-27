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
    public class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.HasMany(x => x.ProductStorages)
                .WithOne(x => x.Storage)
                .HasForeignKey(x => x.StorageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.FromProductRestorage)
                .WithOne(x => x.FromStorage)
                .HasForeignKey(x => x.FromStorageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ToProductRestorage)
                .WithOne(x => x.ToStorage)
                .HasForeignKey(x => x.ToStorageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
