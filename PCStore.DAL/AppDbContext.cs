using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PCStore.DAL.Seeeding;
using PCStore.Data.Models;

namespace PCStore.DAL;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Characteristics> Characteristics { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contragent> Contragents { get; set; }
    public DbSet<ContragentDescription> ContragentDescriptions { get; set; }
    public DbSet<Count> Counts { get; set; }
    public DbSet<CountManipulation> CountManipulations { get; set; }
    public DbSet<CountOperation> CountOperations { get; set; }
    public DbSet<DeliverAddress> DeliverAddresses { get; set; }
    public DbSet<DeliverOption> DeliverOptions { get; set; }
    public DbSet<Inventarizations> Inventarizations { get; set; }
    public DbSet<Manipulation> Manipulations { get; set; }
    public DbSet<NakladnaType> NakladnaTypes { get; set; }
    public DbSet<Nakladni> Nakladnis { get; set; }
    public DbSet<NakladniProducts> NakladniProducts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<Photos> Photos { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCharacteristics> ProductCharacteristics { get; set; }
    public DbSet<ProductInventarization> ProductInventarizations { get; set; }
    public DbSet<ProductRestorage> ProductRestorages { get; set; }
    public DbSet<ProductStorages> ProductStorages { get; set; }
    public DbSet<Restorages> Restorages { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Storage> Storages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public void SeedData()
    {
        if (!Brands.Any() && !Categories.Any() && !Products.Any())
        {
            ProductsSeeding.SeedingInit();

            this.Brands.AddRange(ProductsSeeding.Brands);
            this.Categories.AddRange(ProductsSeeding.Categories);
            this.Products.AddRange(ProductsSeeding.Products);
            this.Photos.AddRange(ProductsSeeding.Photoss);
            this.NakladnaTypes.AddRange(ProductsSeeding.NakladnaTypes);
            this.Statuses.AddRange(ProductsSeeding.Statuses);

            this.SaveChanges();
        }
    }
}