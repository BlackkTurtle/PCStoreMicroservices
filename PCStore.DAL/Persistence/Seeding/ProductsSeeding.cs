using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Persistence.Seeding
{
    public static class ProductsSeeding
    {
        public static List<Advertisement> Advertisements { get; set; } = new List<Advertisement>();
        public static List<Brand> Brands { get; set; } = new List<Brand>();
        public static List<Category> Categories { get; set; } = new List<Category>();
        public static List<Characteristics> Characteristics { get; set; } = new List<Characteristics>();
        public static List<Comment> Comments { get; set; } = new List<Comment>();
        public static List<Product> Products { get; set; } = new List<Product>();
        public static List<ProductCharacteristics> ProductCharacteristics { get; set; } = new List<ProductCharacteristics>();
        public static List<ProductStorages> ProductStorages { get; set; } = new List<ProductStorages>();
        public static List<Photos> Photoss { get; set; } = new List<Photos>();
        public static List<Storage> Storages { get; set; } = new List<Storage>();

        public static void SeedingInit()
        {
            SeedAdvertisementEntities();
            SeedBrandEntities();
            SeedCategoryEntities();
            SeedCharacteristicEntities();
            SeedStorageEntities();
            SeedProductEntities();
            SeedPhotoEntities();
            SeedProductCharacteristicEntities();
            SeedCharacteristicCategoriesEntities();
            SeedCommentEntities();
            SeedProductStorageEntities();
        }

        #region SeedAdvertisements
        private static void SeedAdvertisementEntities()
        {
            var addvertisementsLinks = new List<string>
            {
                "http://localhost:8002/AddvertisementPhotos/advertisement1.jpg",
                "http://localhost:8002/AddvertisementPhotos/advertisement2.jpg",
                "http://localhost:8002/AddvertisementPhotos/advertisement3.jpg"
            };

            for (int i = 0; i < addvertisementsLinks.Count; i++)
            {
                Advertisements.Add(new Advertisement()
                {
                    Id = i + 1,
                    PhotoLink = addvertisementsLinks[i],
                    Order = i
                });
            }
        }
        #endregion

        #region SeedBrands
        private static void SeedBrandEntities()
        {
            string[] BrandNames = new string[] { "DBL Electronics", "MSI", "Toshiba", "Dark Project", "Targa", "Philips", "ergo", "A4Tech", "Vinga", "Intel", "Kingston" };
            for (int i = 1; i <= BrandNames.Length; i++)
            {
                Brands.Add(new Brand()
                {
                    Id = i,
                    Name = BrandNames[i - 1]
                });
            }
        }
        #endregion

        #region SeedCategories
        private static void SeedCategoryEntities()
        {
            var photoLinks = new List<string>
            {
                "http://localhost:8002/CategoryPhotos/1.png", "http://localhost:8002/CategoryPhotos/2.png",
                "http://localhost:8002/CategoryPhotos/3.png", "http://localhost:8002/CategoryPhotos/4.png",
                "http://localhost:8002/CategoryPhotos/5.png", "http://localhost:8002/CategoryPhotos/6.png",
                "http://localhost:8002/CategoryPhotos/7.png", "http://localhost:8002/CategoryPhotos/8.png",
                "http://localhost:8002/CategoryPhotos/9.png", "http://localhost:8002/CategoryPhotos/10.png",
                "http://localhost:8002/CategoryPhotos/11.png", "http://localhost:8002/CategoryPhotos/12.png",
                "http://localhost:8002/CategoryPhotos/13.png", "http://localhost:8002/CategoryPhotos/14.png",
            };

            string[] categoryNames = new string[] { "Кабелі", "Корпуси", "Процесори", "Відеокарти", "Жорсткі диски", "Навушники", "Клавіатури",
                "Мікрофони", "Монітори", "Материнські плати", "Миші", "Оперативна пам'ять", "Акустичні системи", "Веб-камери" };
            for (int i = 1; i <= categoryNames.Length; i++)
            {
                Categories.Add(new Category()
                {
                    Id = i,
                    Name = categoryNames[i - 1],
                    PhotoLink = photoLinks[i - 1]
                });
            }
        }
        #endregion

        #region SeedCharacteristics
        private static void SeedCharacteristicEntities()
        {
            string[] names = new string[]
            {
                "Гарантія", "Роз'єм 1", "Роз'єм 2", "Довжина", "Країна виробник"

            };

            for (int i = 0; i < names.Length; i++)
            {
                Characteristics.Add(new Characteristics()
                {
                    Id = i+1,
                    Name = names[i]
                });
            }
        }
        #endregion

        #region SeedCharacteristicsCategories
        private static void SeedCharacteristicCategoriesEntities()
        {
            int[][] links = new int[][]
            {
                [2, 3, 4],
            };

            for(int i = 0; i < links.GetLength(0); i++)
            {
                Categories[i].Characteristics = Characteristics.Where(x => links[i].Contains(x.Id)).ToList();
            };
        }
        #endregion

        #region SeedComments
        private static void SeedCommentEntities()
        {
            string[] userIds = new string[]
            {
                "user@example.com", "adminUser@example.com","user@example.com","user@example.com","user@example.com","user@example.com",
            };

            string[] fullNames = new string[]
            {
                "FirstName LastName","Admin","FirstName LastName","FirstName LastName","FirstName LastName","FirstName LastName",
            };

            int[] productIds = new int[]
            {
                1, 1, 1, 1, 1, 1
            };

            int[] parentIds = new int[]
            {
                0, 1, 0, 0, 0, 0,
            };

            int[] ratings = new int[]
            {
                0, 0, 0, 5, 4, 4
            };

            string[] contents = new string[]
            {
                "Цей кабель підтримує 1080p 120Hz?", "Не підтримує.", "Скільки метрів має цей кабель?", "Файний кабель", "Норм кабель", "Хороший кабель"
            };

            bool[] isReviews = new bool[]
            {
                false, false, false, true, true, true
            };

            for (int i = 0; i < userIds.Length; i++)
            {
                Comments.Add(new Comment
                {
                    Id = i + 1,
                    UserId = userIds[i],
                    FullName = fullNames[i],
                    ProductId = productIds[i],
                    ParentId = parentIds[i] == 0 ? null : parentIds[i],
                    CreatedDate = DateTime.Now,
                    DateModified = DateTime.Now.AddMinutes(1),
                    Rating = ratings[i] == 0 ? null : ratings[i],
                    Content = contents[i],
                    IsReview = isReviews[i],
                    CommentStatus = Data.Models.Enums.CommentStatusEnum.Valid
                });
            }
        }
        #endregion

        #region SeedPhotos
        private static void SeedPhotoEntities()
        {
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
                        PhotoLink = photoLinks[i - 1, j],
                    });
                    a++;
                }
            }
        }
        #endregion

        #region SeedProducts
        private static void SeedProductEntities()
        {
            string[] productNames = new string[]
            {
                "Кабель HDMI to DVI-D Cable", "Корпус Vinga Orc", "Процесор Intel I5 8400", "Відеокарта GTX 1660Ti MSI Gaming X", " Жорсткий диск Toshiba HDD 1Tb",
                "Навушники ergo BT490", "Клавіатура Dark Project KB104A", "Мікрофон Mega Microphone 3000", "Монітор Philips 2473LE FullHD", "Материнська плата MSI B360M Gaming Plus",
                "Миша A4Tech N70-FX", "Оперативна пам'ять Kingston Fury 8Gb 2666", "Акустична система Targa EVO 550", "Веб-камера A4Tech NFL Webcam"
            };

            int[] categoryIds = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14
            };

            int[] brandIds = new int[]
            {
                1, 9, 10, 2, 3, 7, 5, 1, 6, 2, 8, 11, 5, 8
            };

            double[] prices = new double[]
            {
                199, 1999, 3799, 7999, 1499, 699, 3699, 699, 2799, 2749, 349, 1199, 899, 399
            };

            for (int i = 0; i < productNames.Length; i++)
            {
                Products.Add(new Product()
                {
                    Id = i+1,
                    Name = productNames[i],
                    CategoryId = categoryIds[i],
                    BrandId = brandIds[i],
                    Price = prices[i],
                    CreatedDate = DateTime.Now
                });
            };
        }
        #endregion

        #region SeedProductCharacteristics
        private static void SeedProductCharacteristicEntities()
        {
            string[] names = new string[]
            {
                "12 місяців", "HDMI", "DVI-D", "2m", "Китай",

            };

            int[] characteristicIds = new int[]
            {
                1 , 2 , 3 , 4 , 5,

            };

            int[] productIds = new int[]
            {
                1, 1, 1, 1, 1,

            };

            int[] characteristicsOrder = new int[]
            {
                5, 1, 2, 3, 4,

            };

            for (int i = 0; i < names.Length; i++)
            {
                ProductCharacteristics.Add(new ProductCharacteristics()
                {
                    Id = i+1,
                    Name = names[i],
                    CharacteristicId = characteristicIds[i],
                    ProductId = productIds[i],
                    Order = characteristicsOrder[i]
                });
            };
        }
        #endregion

        #region SeedProductStorages
        private static void SeedProductStorageEntities()
        {
            int[] productIds = new int[]
            {
                1
            };

            int[] storageIds = new int[]
            {
                1
            };

            int[] quantities = new int[]
            {
                10
            };

            for (int i = 0;i < productIds.Length; i++)
            {
                ProductStorages.Add(new ProductStorages()
                {
                    Id = i+1,
                    ProductId = productIds[i],
                    StorageId = storageIds[i],
                    Quantity = quantities[i]
                });
            };
        }
        #endregion

        #region SeedStorages
        private static void SeedStorageEntities()
        {
            string[] names = new string[]
            {
                "Main Storage"
            };

            for (int i = 0;i < names.Length; i++)
            {
                Storages.Add(new Storage()
                {
                    Id = i+1,
                    Name = names[i],
                });
            };
        }
        #endregion
    }
}
