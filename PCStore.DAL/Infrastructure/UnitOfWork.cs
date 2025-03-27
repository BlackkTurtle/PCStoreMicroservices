using PCStore.DAL.Infrastructure.Interfaces;
using PCStore.DAL.Repositories.Contracts;
using System.Threading.Tasks;

namespace PCStore.DAL.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public IBrandRepository BrandRepository { get; }
    public ICategoryRepository CategoryRepository { get; }
    public ICharacteristicsRepository CharacteristicsRepository { get; }
    public ICommentRepository CommentRepository { get; }
    public IContragentRepository ContragentRepository { get; }
    public IContragentDescriptionRepository ContragentDescriptionRepository { get; }
    public ICountRepository CountRepository { get; }
    public ICountManipulationRepository CountManipulationRepository { get; }
    public ICountOperationRepository CountOperationRepository { get; }
    public IDeliverAddressRepository DeliverAddressRepository { get; }
    public IDeliverOptionRepository DeliverOptionRepository { get; }
    public IInventarizationRepository InventarizationRepository { get; }
    public IManipulationRepository ManipulationRepository { get; }
    public INakladnaTypeRepository NakladnaTypeRepository { get; }
    public INakladniRepository NakladniRepository { get; }
    public INakladniProductsRepository NakladniProductsRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IPaymentRepository PaymentRepository { get; }
    public IPaymentTypeRepository PaymentTypeRepository { get; }
    public IPhotosRepository PhotosRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IProductCharacteristicsRepository ProductCharacteristicsRepository { get; }
    public IProductInventarizationRepository ProductInventarizationRepository { get; }
    public IProductRestorageRepository ProductRestorageRepository { get; }
    public IProductStoragesRepository ProductStoragesRepository { get; }
    public IRestorageRepository RestorageRepository { get; }
    public IStatusRepository StatusRepository { get; }
    public IStorageRepository StorageRepository { get; }

    public UnitOfWork
        (AppDbContext cinemaContext,
        IBrandRepository brandRepository,
        ICategoryRepository categoryRepository,
        ICharacteristicsRepository characteristicsRepository,
        IContragentRepository contragentRepository,
        IContragentDescriptionRepository contragentDescriptionRepository,
        ICountRepository countRepository,
        ICountManipulationRepository countManipulationRepository,
        ICountOperationRepository countOperationRepository,
        IDeliverAddressRepository deliverAddressRepository,
        IDeliverOptionRepository deliverOptionRepository,
        IInventarizationRepository inventarizationRepository,
        IManipulationRepository manipulationRepository,
        INakladnaTypeRepository nakladnaTypeRepository,
        INakladniRepository nakladniRepository,
        INakladniProductsRepository nakladniProductsRepository,
        IOrderRepository orderRepository,
        IPaymentRepository paymentRepository,
        IPaymentTypeRepository paymentTypeRepository,
        IPhotosRepository photosRepository,
        IProductRepository productRepository,
        IProductCharacteristicsRepository productCharacteristicsRepository,
        IProductInventarizationRepository productInventarizationRepository,
        IProductRestorageRepository productRestorageRepository,
        IProductStoragesRepository productStoragesRepository,
        IRestorageRepository restorageRepository,
        IStorageRepository storageRepository,
        ICommentRepository commentRepository,
        IStatusRepository statusRepository)
    {
        _appDbContext = cinemaContext;
        BrandRepository = brandRepository;
        CategoryRepository = categoryRepository;
        CharacteristicsRepository = characteristicsRepository;
        ContragentRepository = contragentRepository;
        ContragentDescriptionRepository = contragentDescriptionRepository;
        CountRepository = countRepository;
        CountManipulationRepository = countManipulationRepository;
        CountOperationRepository = countOperationRepository;
        DeliverAddressRepository = deliverAddressRepository;
        DeliverOptionRepository = deliverOptionRepository;
        InventarizationRepository = inventarizationRepository;
        ManipulationRepository = manipulationRepository;
        NakladnaTypeRepository = nakladnaTypeRepository;
        NakladniRepository = nakladniRepository;
        NakladniProductsRepository = nakladniProductsRepository;
        OrderRepository = orderRepository;
        PaymentRepository = paymentRepository;
        PaymentTypeRepository = paymentTypeRepository;
        PhotosRepository = photosRepository;
        ProductRepository = productRepository;
        ProductCharacteristicsRepository = productCharacteristicsRepository;
        ProductInventarizationRepository = productInventarizationRepository;
        ProductRestorageRepository = productRestorageRepository;
        ProductStoragesRepository = productStoragesRepository;
        RestorageRepository = restorageRepository;
        StorageRepository = storageRepository;
        CommentRepository = commentRepository;
        StatusRepository = statusRepository;
    }

    public async Task SaveChangesAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }
}