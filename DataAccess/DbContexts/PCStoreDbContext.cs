using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DbContexts
{
    public partial class PCStoreDbContext:DbContext
    {

        public PCStoreDbContext(DbContextOptions<PCStoreDbContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<PartOrder> PartOrders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }

        public virtual DbSet<Types> Types { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q05O5DB;Initial Catalog=PCStoreMicroservices;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId).HasColumnName("BrandID");
                entity.Property(e => e.BrandName).HasMaxLength(30);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId).HasName("PK__Comments__C3B4DFAA228ED363");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");
                entity.Property(e => e.Comment1)
                    .HasMaxLength(1000)
                    .HasColumnName("Comment");
                entity.Property(e => e.CommentDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Article)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comments_Products");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF4D4E9B9E");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.Adress).HasMaxLength(200);
                entity.Property(e => e.OrderDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.StatusId).HasColumnName("StatusID");
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Statuses");
            });

            modelBuilder.Entity<PartOrder>(entity =>
            {
                entity.HasKey(e => e.PorderId).HasName("PK__PartOrde__8BC48CFACF6672FB");

                entity.Property(e => e.PorderId).HasColumnName("POrderID");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.ArticleNavigation).WithMany(p => p.PartOrders)
                    .HasForeignKey(d => d.Article)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartOrders_Products");

                entity.HasOne(d => d.Order).WithMany(p => p.PartOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PartOrders_Orders");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Article).HasName("PK__Products__4943444B3CACFB32");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Picture).HasMaxLength(1000);
                entity.Property(e => e.ProductInfo).HasMaxLength(1000);

                entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Brands");

                entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Products)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Types");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.StatusId).HasName("PK__Statuses__C8EE2043B71385D9");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");
                entity.Property(e => e.StatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<Types>(entity =>
            {
                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
