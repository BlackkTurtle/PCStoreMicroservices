using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using PCStore.API.Extensions;
using PCStore.DAL.Infrastructure.Interfaces;
using PCStore.Data.Models;

namespace PCStoreService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly ILogger<BrandController> _logger;
        private IUnitOfWork _EFuow;
        private IEnumerable<Brand> _brands;
        private readonly IDistributedCache distributedCache;
        public BrandController(ILogger<BrandController> logger,
            IUnitOfWork unitOfWork,
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
                    _brands = await _EFuow.BrandRepository.GetAsync();

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
        }/*
        [HttpGet("NameLike/{namelike}")]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrandsByNAMELikeAsync(string namelike)
        {
            try
            {
                var results = await _EFuow.eFBrandsRepository.GetBrandsByNameLikeAsync(namelike);
                _logger.LogInformation($"Отримали всі Brands з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetBrandsByNAMELikeAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }*/
    }
}
