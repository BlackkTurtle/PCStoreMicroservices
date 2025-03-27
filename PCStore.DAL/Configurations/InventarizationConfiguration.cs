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
    public class InventarizationConfiguration : IEntityTypeConfiguration<Inventarizations>
    {
        public void Configure(EntityTypeBuilder<Inventarizations> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreationDate);

            builder.HasMany(x => x.ProductInventarizations)
                .WithOne(x => x.Inventarizations)
                .HasForeignKey(x => x.InventarizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
