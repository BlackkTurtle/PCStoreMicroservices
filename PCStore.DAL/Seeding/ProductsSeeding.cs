using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Seeeding
{
    public static class ProductsSeeding
    {
        public static List<Brand> Brands { get; set; } = new List<Brand>();
        public static List<Category> Categories { get; set; } = new List<Category>();
        public static List<Product> Products { get; set; } = new List<Product>();
        public static List<Photos> Photoss { get; set; } = new List<Photos>();
        public static List<NakladnaType> NakladnaTypes { get; set; }= new List<NakladnaType>();
        public static List<Status> Statuses { get; set; }=new List<Status>();

        public static void SeedingInit()
        {
            String[] BrandNames = new String[] { "DBL Electronics", "MSI", "Toshiba", "Dark Project", "Targa", "Philips", "ergo", "A4Tech", "Vinga", "Intel","Kingston" };
            for (int i = 1; i <= BrandNames.Length; i++)
            {
                Brands.Add(new Brand()
                {
                    Id = i,
                    Name = BrandNames[i - 1]
                });
            }

            String[] categoryNames = new String[] { "Cable","Case","CPU","GPU","HDD","Headset","Keyboard","Microphone","Monitor","Motherboard","Mouse","RAM","Speakers","Webcam" };
            for (int i = 1; i <= categoryNames.Length; i++)
            {
                Categories.Add(new Category()
                {
                    Id = i,
                    Name = categoryNames[i - 1]
                });
            }

            Products.Add(new Product()
            {
                Id=1,
                Name="HDI to DVI-D Cable",
                CategoryId=1,
                BrandId=1,
                Price=199,
                CreatedDate= DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 2,
                Name = "Vinga Orc",
                CategoryId = 2,
                BrandId = 9,
                Price = 1999,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 3,
                Name = "Intel I5 8400",
                CategoryId = 3,
                BrandId = 10,
                Price = 3799,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 4,
                Name = "GTX 1660Ti MSI Gaming X",
                CategoryId = 4,
                BrandId = 2,
                Price = 7999,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 5,
                Name = "Toshiba HDD 1Tb",
                CategoryId = 5,
                BrandId = 3,
                Price = 1499,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 6,
                Name = "ergo BT490",
                CategoryId = 6,
                BrandId = 7,
                Price = 699,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 7,
                Name = "Dark Project KB104A",
                CategoryId = 7,
                BrandId = 5,
                Price = 3699,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 8,
                Name = "Mega Microphone 3000",
                CategoryId = 8,
                BrandId = 1,
                Price = 699,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 9,
                Name = "Philips 2473LE FullHD",
                CategoryId = 9,
                BrandId = 6,
                Price = 2799,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 10,
                Name = "MSI B360M Gaming Plus",
                CategoryId = 10,
                BrandId = 2,
                Price = 2749,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 11,
                Name = "A4Tech N70-FX",
                CategoryId = 11,
                BrandId = 8,
                Price = 349,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 12,
                Name = "Kingston Fury 8Gb 2666",
                CategoryId = 12,
                BrandId = 11,
                Price = 1199,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 13,
                Name = "Targa EVO 550",
                CategoryId = 13,
                BrandId = 5,
                Price = 899,
                CreatedDate = DateTime.Now
            });
            Products.Add(new Product()
            {
                Id = 14,
                Name = "A4Tech NFL Webcam",
                CategoryId = 14,
                BrandId = 8,
                Price = 399,
                CreatedDate = DateTime.Now
            });

            var photoLinks = new string[,]
{
    { "http://localhost:8002/PhotoFiles/1.jpg", "http://localhost:8002/PhotoFiles/2.jpg", "http://localhost:8002/PhotoFiles/3.jpg" },
    { "http://localhost:8002/PhotoFiles/4.jpg", "http://localhost:8002/PhotoFiles/5.jpg", "http://localhost:8002/PhotoFiles/6.jpg" },
    { "http://localhost:8002/PhotoFiles/7.jpg", "http://localhost:8002/PhotoFiles/8.jpg", "http://localhost:8002/PhotoFiles/9.jpg" },
    { "http://localhost:8002/PhotoFiles/10.jpg", "http://localhost:8002/PhotoFiles/11.jpg", "http://localhost:8002/PhotoFiles/12.jpg" },
    { "http://localhost:8002/PhotoFiles/13.jpg", "http://localhost:8002/PhotoFiles/14.jpg", "http://localhost:8002/PhotoFiles/15.jpg" },
    { "http://localhost:8002/PhotoFiles/16.jpg", "http://localhost:8002/PhotoFiles/17.jpg", "http://localhost:8002/PhotoFiles/18.jpg" },
    { "http://localhost:8002/PhotoFiles/19.jpg", "http://localhost:8002/PhotoFiles/20.jpg", "http://localhost:8002/PhotoFiles/21.jpg" },
    { "http://localhost:8002/PhotoFiles/22.jpg", "http://localhost:8002/PhotoFiles/23.jpg", "http://localhost:8002/PhotoFiles/24.jpg" },
    { "http://localhost:8002/PhotoFiles/25.jpg", "http://localhost:8002/PhotoFiles/26.jpg", "http://localhost:8002/PhotoFiles/27.jpg" },
    { "http://localhost:8002/PhotoFiles/28.jpg", "http://localhost:8002/PhotoFiles/29.jpg", "http://localhost:8002/PhotoFiles/30.jpg" },
    { "http://localhost:8002/PhotoFiles/31.jpg", "http://localhost:8002/PhotoFiles/32.jpg", "http://localhost:8002/PhotoFiles/33.jpg" },
    { "http://localhost:8002/PhotoFiles/34.jpg", "http://localhost:8002/PhotoFiles/35.jpg", "http://localhost:8002/PhotoFiles/36.jpg" },
    { "http://localhost:8002/PhotoFiles/37.jpg", "http://localhost:8002/PhotoFiles/38.jpg", "http://localhost:8002/PhotoFiles/39.jpg" },
    { "http://localhost:8002/PhotoFiles/40.jpg", "http://localhost:8002/PhotoFiles/41.jpg", "http://localhost:8002/PhotoFiles/42.jpg" }
};

            int a = 1;
            for (int i = 1; i <= Math.Min(Products.Count, photoLinks.GetLength(0)); i++)
            {
                for (int j = 0; j < 3; j++) 
                {
                    Photoss.Add(new Photos()
                    {
                        Id = a,
                        ProductId = i,
                        PhotoLink=photoLinks[i-1,j],
                    });
                    a++;
                }
            }

            String[] nakladnaTypes = new String[] { "Pributkova","Vidatkova" };
            for (int i = 1; i <= nakladnaTypes.Length; i++)
            {
                NakladnaTypes.Add(new NakladnaType()
                {
                    Id = i,
                    Name = categoryNames[i - 1]
                });
            }

            String[] statusNames = new String[] { "Delivered", "Cancelled","Delivering","Review" };
            for (int i = 1; i <= statusNames.Length; i++)
            {
                Statuses.Add(new Status()
                {
                    Id = i,
                    Name = statusNames[i - 1]
                });
            }
        }
    }
}
