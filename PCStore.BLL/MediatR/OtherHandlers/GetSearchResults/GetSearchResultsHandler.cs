using FluentResults;
using MediatR;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Specifications.AdvertisementSpecifications;
using PCStore.BLL.Specifications.BrandSpecifications;
using PCStore.BLL.Specifications.CategorySpecifications;
using PCStore.BLL.Specifications.ProductSpecifications;
using PCStore.DAL.Repositories.Contracts;
using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.DTOs.CategoryDTOs;
using PCStore.Data.DTOs.OtherDTOs;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.OtherHandlers.GetSearchResults
{
    public class GetSearchResultsHandler : IRequestHandler<GetSearchResultsQuery, Result<SearchBarResultDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerService _logger;

        public GetSearchResultsHandler(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<SearchBarResultDTO>> Handle(GetSearchResultsQuery request, CancellationToken cancellationToken)
        {
            var result = new SearchBarResultDTO()
            {
                Brands = (List<GetBrandDTO>)await unitOfWork.BrandRepository.GetAllAsync(new BrandIdNameSpecification(request.nameLike)),
                Categorys = (List<CategoryIdNameDTO>)await unitOfWork.CategoryRepository.GetAllAsync(new CategoryIdNameSpecification(request.nameLike)),
                Products = (List<ProductIdNameDTO>)await unitOfWork.ProductRepository.GetAllAsync(new ProductIdNameSpecification(request.nameLike))
            };

            return Result.Ok(result);
        }
    }
}
