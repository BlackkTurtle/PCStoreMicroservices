using PCStore.DAL.Caching.RedisCache;
using PCStore.DAL.Persistence;
using PCStore.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRedisCacheService redisCacheService;
        private readonly AppDbContext _dbContext;

        public UnitOfWork(IRedisCacheService redisCacheService, AppDbContext dbContext)
        {
            this.redisCacheService = redisCacheService;
            _dbContext = dbContext;
        }

        private IAdvertisementRepository advertisementRepository;
        private IBrandRepository brandRepository;
        private ICatalogRepository catalogRepository;
        private ICategoryRepository categoryRepository;
        private ICharacteristicsRepository characteristicsRepository;
        private ICommentRepository commentRepository;
        private IContragentRepository contragentRepository;
        private IContragentDescriptionRepository contragentDescriptionRepository;
        private ICountManipulationRepository countManipulationRepository;
        private ICountOperationRepository countOperationRepository;
        private ICountRepository countRepository;
        private IDeliverAddressRepository deliverAddressRepository;
        private IDeliverOptionRepository deliverOptionRepository;
        private IInventarizationRepository inventarizationRepository;
        private IManipulationRepository manipulationRepository;
        private INakladniProductsRepository nakladniProductsRepository;
        private INakladniRepository nakladniRepository;
        private IOrderRepository orderRepository;
        private IPaymentRepository paymentRepository;
        private IPaymentTypeRepository paymentTypeRepository;
        private IPhotosRepository photosRepository;
        private IProductCharacteristicsRepository productCharacteristicsRepository;
        private IProductInventarizationRepository productInventarizationRepository;
        private IProductRepository productRepository;
        private IProductRestorageRepository productRestorageRepository;
        private IProductStoragesRepository productStoragesRepository;
        private IRestorageRepository restorageRepository;
        private IStorageRepository storageRepository;

        public IAdvertisementRepository AdvertisementRepository
        {
            get
            {
                if (advertisementRepository is null)
                {
                    advertisementRepository = new AdvertisementRepository(_dbContext, redisCacheService);
                }

                return advertisementRepository;
            }
        }

        public IBrandRepository BrandRepository
        {
            get
            {
                if (brandRepository is null)
                {
                    brandRepository = new BrandRepository(_dbContext, redisCacheService);
                }

                return brandRepository;
            }
        }

        public ICatalogRepository CatalogRepository
        {
            get
            {
                if (catalogRepository is null)
                {
                    catalogRepository = new CatalogRepository(_dbContext, redisCacheService);
                }

                return catalogRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (categoryRepository is null)
                {
                    categoryRepository = new CategoryRepository(_dbContext, redisCacheService);
                }
                return categoryRepository;
            }
        }

        public ICharacteristicsRepository CharacteristicsRepository
        {
            get
            {
                if (characteristicsRepository is null)
                {
                    characteristicsRepository = new CharacteristicsRepository(_dbContext, redisCacheService);
                }
                return characteristicsRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (commentRepository is null)
                {
                    commentRepository = new CommentRepository(_dbContext, redisCacheService);
                }
                return commentRepository;
            }
        }

        public IContragentRepository ContragentRepository
        {
            get
            {
                if (contragentRepository is null)
                {
                    contragentRepository = new ContragentRepository(_dbContext, redisCacheService);
                }
                return contragentRepository;
            }
        }

        public IContragentDescriptionRepository ContragentDescriptionRepository
        {
            get
            {
                if (contragentDescriptionRepository is null)
                {
                    contragentDescriptionRepository = new ContragentDescriptionRepository(_dbContext, redisCacheService);
                }
                return contragentDescriptionRepository;
            }
        }

        public ICountManipulationRepository CountManipulationRepository
        {
            get
            {
                if (countManipulationRepository is null)
                {
                    countManipulationRepository = new CountManipulationRepository(_dbContext, redisCacheService);
                }
                return countManipulationRepository;
            }
        }

        public ICountOperationRepository CountOperationRepository
        {
            get
            {
                if (countOperationRepository is null)
                {
                    countOperationRepository = new CountOperationRepository(_dbContext, redisCacheService);
                }
                return countOperationRepository;
            }
        }

        public ICountRepository CountRepository
        {
            get
            {
                if (countRepository is null)
                {
                    countRepository = new CountRepository(_dbContext, redisCacheService);
                }
                return countRepository;
            }
        }

        public IDeliverAddressRepository DeliverAddressRepository
        {
            get
            {
                if (deliverAddressRepository is null)
                {
                    deliverAddressRepository = new DeliverAddressRepository(_dbContext, redisCacheService);
                }
                return deliverAddressRepository;
            }
        }

        public IDeliverOptionRepository DeliverOptionRepository
        {
            get
            {
                if (deliverOptionRepository is null)
                {
                    deliverOptionRepository = new DeliverOptionRepository(_dbContext, redisCacheService);
                }
                return deliverOptionRepository;
            }
        }

        public IInventarizationRepository InventarizationRepository
        {
            get
            {
                if (inventarizationRepository is null)
                {
                    inventarizationRepository = new InventarizationRepository(_dbContext, redisCacheService);
                }
                return inventarizationRepository;
            }
        }

        public IManipulationRepository ManipulationRepository
        {
            get
            {
                if (manipulationRepository is null)
                {
                    manipulationRepository = new ManipulationRepository(_dbContext, redisCacheService);
                }
                return manipulationRepository;
            }
        }

        public INakladniProductsRepository NakladniProductsRepository
        {
            get
            {
                if (nakladniProductsRepository is null)
                {
                    nakladniProductsRepository = new NakladniProductsRepository(_dbContext, redisCacheService);
                }
                return nakladniProductsRepository;
            }
        }

        public INakladniRepository NakladniRepository
        {
            get
            {
                if (nakladniRepository is null)
                {
                    nakladniRepository = new NakladniRepository(_dbContext, redisCacheService);
                }
                return nakladniRepository;
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if (orderRepository is null)
                {
                    orderRepository = new OrderRepository(_dbContext, redisCacheService);
                }
                return orderRepository;
            }
        }

        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (paymentRepository is null)
                {
                    paymentRepository = new PaymentRepository(_dbContext, redisCacheService);
                }
                return paymentRepository;
            }
        }

        public IPaymentTypeRepository PaymentTypeRepository
        {
            get
            {
                if (paymentTypeRepository is null)
                {
                    paymentTypeRepository = new PaymentTypeRepository(_dbContext, redisCacheService);
                }
                return paymentTypeRepository;
            }
        }

        public IPhotosRepository PhotosRepository
        {
            get
            {
                if (photosRepository is null)
                {
                    photosRepository = new PhotosRepository(_dbContext, redisCacheService);
                }
                return photosRepository;
            }
        }

        public IProductCharacteristicsRepository ProductCharacteristicsRepository
        {
            get
            {
                if (productCharacteristicsRepository is null)
                {
                    productCharacteristicsRepository = new ProductCharacteristicsRepository(_dbContext, redisCacheService);
                }
                return productCharacteristicsRepository;
            }
        }

        public IProductInventarizationRepository ProductInventarizationRepository
        {
            get
            {
                if (productInventarizationRepository is null)
                {
                    productInventarizationRepository = new ProductInventarizationRepository(_dbContext, redisCacheService);
                }
                return productInventarizationRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (productRepository is null)
                {
                    productRepository = new ProductRepository(_dbContext, redisCacheService);
                }
                return productRepository;
            }
        }

        public IProductRestorageRepository ProductRestorageRepository
        {
            get
            {
                if (productRestorageRepository is null)
                {
                    productRestorageRepository = new ProductRestorageRepository(_dbContext, redisCacheService);
                }
                return productRestorageRepository;
            }
        }

        public IProductStoragesRepository ProductStoragesRepository
        {
            get
            {
                if (productStoragesRepository is null)
                {
                    productStoragesRepository = new ProductStoragesRepository(_dbContext, redisCacheService);
                }
                return productStoragesRepository;
            }
        }

        public IRestorageRepository RestorageRepository
        {
            get
            {
                if (restorageRepository is null)
                {
                    restorageRepository = new RestorageRepository(_dbContext, redisCacheService);
                }
                return restorageRepository;
            }
        }

        public IStorageRepository StorageRepository
        {
            get
            {
                if (storageRepository is null)
                {
                    storageRepository = new StorageRepository(_dbContext, redisCacheService);
                }
                return storageRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
