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
    public class DeliverOptionConfiguration : IEntityTypeConfiguration<DeliverOption>
    {
        public void Configure(EntityTypeBuilder<DeliverOption> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.HasMany(x => x.DeliverAddresses)
                .WithOne(x => x.DeliverOption)
                .HasForeignKey(x => x.DeliverOptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
