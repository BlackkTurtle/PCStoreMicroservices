﻿using DataAccess.Models;
using DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace PCStoreService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFStatusController : ControllerBase
    {
        private readonly ILogger<EFStatusController> _logger;
        private IEFUnitOfWork _EFuow;
        public EFStatusController(ILogger<EFStatusController> logger,
            IEFUnitOfWork unitOfWork)
        {
            _logger = logger;
            _EFuow = unitOfWork;
        }

        //GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetAllStatusesAsync()
        {
            try
            {
                var results = await _EFuow.eFStatusesRepository.GetAllAsync();
                _logger.LogInformation($"Отримали всі Statuses з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetAllStatusesAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
