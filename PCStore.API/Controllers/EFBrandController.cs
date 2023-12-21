using DataAccess.Models;
using DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using PCStore.API.Consumers;
using PCStore.API.Extensions;

namespace PCStoreService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFBrandController : ControllerBase
    {
        private readonly ILogger<EFBrandController> _logger;
        private IEFUnitOfWork _EFuow;
        private IEnumerable<Brand> _brands;
        private readonly IDistributedCache distributedCache;
        public EFBrandController(ILogger<EFBrandController> logger,
            IEFUnitOfWork unitOfWork,
            IDistributedCache distributedCache)
        {
            _logger = logger;
            _EFuow = unitOfWork;
            this.distributedCache = distributedCache;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrandsAsync()
        {
            try
            {
                _brands = null;
                string recordKey = "Brands" + DateTime.Now.ToString("ÿyyyMMdd_hhmm");
                _brands = await distributedCache.GetRecordAsync<IEnumerable<Brand>>(recordKey);
                if (_brands is null)
                {
                    _brands = await _EFuow.eFBrandsRepository.GetAllAsync();

                    await distributedCache.SetRecordAsync(recordKey, _brands);
                }
                _logger.LogInformation($"Отримали всі Brands з бази даних!");
                return Ok(_brands);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllBrandsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
