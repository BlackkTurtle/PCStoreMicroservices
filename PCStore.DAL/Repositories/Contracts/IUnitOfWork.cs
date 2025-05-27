using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Repositories.Contracts
{
    public interface IUnitOfWork
    {
        IAdvertisementRepository AdvertisementRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICharacteristicsRepository CharacteristicsRepository { get; }
        ICommentRepository CommentRepository { get; }
        IContragentRepository ContragentRepository { get; }
        IContragentDescriptionRepository ContragentDescriptionRepository { get; }
        ICountManipulationRepository CountManipulationRepository { get; }
        ICountOperationRepository CountOperationRepository { get; }
        ICountRepository CountRepository { get; }
        IDeliverAddressRepository DeliverAddressRepository { get; }
        IDeliverOptionRepository DeliverOptionRepository { get; }
        IInventarizationRepository InventarizationRepository { get; }
        IManipulationRepository ManipulationRepository { get; }
        INakladniProductsRepository NakladniProductsRepository { get; }
        INakladniRepository NakladniRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPaymentRepository PaymentRepository { get; }
        IPaymentTypeRepository PaymentTypeRepository { get; }
        IPhotosRepository PhotosRepository { get; }
        IProductCharacteristicsRepository ProductCharacteristicsRepository { get; }
        IProductInventarizationRepository ProductInventarizationRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductRestorageRepository ProductRestorageRepository { get; }
        IProductStoragesRepository ProductStoragesRepository { get; }
        IRestorageRepository RestorageRepository { get; }
        IStorageRepository StorageRepository { get; }
        public Task<int> SaveChangesAsync();
    }
}
