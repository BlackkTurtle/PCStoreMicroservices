using FluentResults;
using MediatR;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Specifications.AdvertisementSpecifications;
using PCStore.DAL.Repositories.Contracts;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.ProductHandlers.GetLastNProductsWithImage
{
    public class GetLastNProductsWithImageHandler : IRequestHandler<GetLastNProductsWithImageQuery, Result<List<GetProductWithRatingDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerService _logger;

        public GetLastNProductsWithImageHandler(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<List<GetProductWithRatingDTO>>> Handle(GetLastNProductsWithImageQuery request, CancellationToken cancellationToken)
        {
            var entitiesFromDB = await unitOfWork.ProductRepository
                .GetLastNProductsWith1Photo(request.n);

            if (entitiesFromDB is null)
            {
                string errorMsg = "Cannot find entities!";
                _logger.LogError(request, errorMsg);
                return new Error(errorMsg);
            }

            var result = new List<GetProductWithRatingDTO>();

            foreach (var entity in entitiesFromDB)
            {
                result.Add(new GetProductWithRatingDTO()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Rating = entity.Comments.Average(x => (double?)x.Rating) ?? 0.0,
                    Availlability = await unitOfWork.ProductStoragesRepository.CheckAvaillabilityByProductId(entity.Id),
                    PhotoLink = entity.Photos.FirstOrDefault()?.PhotoLink,
                    Price = entity.Price,
                });
            }

            return Result.Ok(result);
        }
    }
}
