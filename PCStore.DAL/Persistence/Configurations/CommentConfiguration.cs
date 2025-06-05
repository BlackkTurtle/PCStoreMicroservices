using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Data.Models;

namespace PCStore.DAL.Persistence.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserId)
                .HasMaxLength(50);

            builder.Property(x => x.FullName)
                .HasMaxLength(60);

            builder.Property(x => x.CreatedDate);

            builder.Property(x => x.DateModified);

            builder.Property(x => x.Rating);

            builder.Property(x => x.CommentStatus);

            builder.Property(x => x.Content)
                .HasMaxLength(500);

            builder.Property(x => x.IsReview);

            builder.HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Product)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ProductId);
        }
    }
}
