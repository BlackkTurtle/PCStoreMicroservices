using DataAccess.DbContexts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace PCStore.API.Seeding
{
    public class DbSeeding
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<PCStoreDbContext>();
                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(new Brand()
                    {
                        BrandName = "MSI"
                    }, new Brand()
                    {
                        BrandName = "Dark project"
                    });
                }
                if (!context.Types.Any())
                {
                    context.Types.AddRange(new Types()
                    {
                        TypeName="CPU"
                    },new Types()
                    {
                        TypeName="Motherboard"
                    }, new Types()
                    {
                        TypeName = "Keyboard"
                    });
                }
                if (!context.Statuses.Any())
                {
                    context.Statuses.AddRange(new Status()
                    {
                        StatusName="Shipping"
                    },new Status()
                    {
                        StatusName="Delivered"
                    }, new Status()
                    {
                        StatusName = "Cancelled"
                    });
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new Product()
                    {
                        Name="Dark project KD104A",
                        Picture="string",
                        Type=9,
                        Price=Convert.ToSingle(69.99),
                        BrandId=2,
                        Availability=true
                    }, new Product()
                    {
                        Name = "MSI B360M Gaming Plus",
                        Picture = "string",
                        Type = 8,
                        Price = Convert.ToSingle(99.99),
                        BrandId = 1,
                        Availability = true
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
