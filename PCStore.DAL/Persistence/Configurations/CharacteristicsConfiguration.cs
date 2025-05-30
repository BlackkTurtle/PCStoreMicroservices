﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Data.Models;

namespace PCStore.DAL.Persistence.Configurations
{
    public class CharacteristicsConfiguration : IEntityTypeConfiguration<Characteristics>
    {
        public void Configure(EntityTypeBuilder<Characteristics> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.HasMany(x => x.ProductCharacteristics)
                .WithOne(x => x.Characteristic)
                .HasForeignKey(x => x.CharacteristicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Characteristics);
        }
    }
}
