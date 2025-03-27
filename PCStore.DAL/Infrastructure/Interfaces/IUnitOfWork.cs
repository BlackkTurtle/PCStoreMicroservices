using PCStore.DAL.Repositories.Contracts;
using System.Threading.Tasks;

namespace PCStore.DAL.Infrastructure.Interfaces;

public interface IUnitOfWork
{
    IBrandRepository BrandRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ICharacteristicsRepository CharacteristicsRepository { get; }
    ICommentRepository CommentRepository { get; }
    IContragentRepository ContragentRepository { get; }
    IContragentDescriptionRepository ContragentDescriptionRepository { get; }
    ICountRepository CountRepository { get; }
    ICountManipulationRepository CountManipulationRepository { get; }
    ICountOperationRepository CountOperationRepository { get; }
    IDeliverAddressRepository DeliverAddressRepository { get; }
    IDeliverOptionRepository DeliverOptionRepository { get; }
    IInventarizationRepository InventarizationRepository { get; }
    IManipulationRepository ManipulationRepository { get; }
    INakladnaTypeRepository NakladnaTypeRepository { get; }
    INakladniRepository NakladniRepository { get; }
    INakladniProductsRepository NakladniProductsRepository { get; }
    IOrderRepository OrderRepository { get; }
    IPaymentRepository PaymentRepository { get; }
    IPaymentTypeRepository PaymentTypeRepository { get; }
    IPhotosRepository PhotosRepository { get; }
    IProductRepository ProductRepository { get; }
    IProductCharacteristicsRepository ProductCharacteristicsRepository { get; }
    IProductInventarizationRepository ProductInventarizationRepository { get; }
    IProductRestorageRepository ProductRestorageRepository { get; }
    IProductStoragesRepository ProductStoragesRepository { get; }
    IRestorageRepository RestorageRepository { get; }
    IStatusRepository StatusRepository { get; }
    IStorageRepository StorageRepository { get; }
    Task SaveChangesAsync();
}