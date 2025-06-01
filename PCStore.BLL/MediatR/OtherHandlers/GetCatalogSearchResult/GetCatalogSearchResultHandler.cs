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
using PCStore.Data.DTOs.OtherDTOs.CatalogDTOs;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.OtherHandlers.GetCatalogSearchResult
{
    public class GetCatalogSearchResultHandler : IRequestHandler<GetCatalogSearchResultQuery, Result<CatalogSearchResultDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerService _logger;

        public GetCatalogSearchResultHandler(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<CatalogSearchResultDTO>> Handle(GetCatalogSearchResultQuery request, CancellationToken cancellationToken)
        {
            var productPaginationDto = await unitOfWork.CatalogRepository.GetCatalogProductPagination(request.catalogSearchRequestDTO);

            var result = new CatalogSearchResultDTO()
            {
                Products = productPaginationDto.Products,
                Brands = await unitOfWork.CatalogRepository.GetBrandsBySearchStrAndCategoryId(
                    request.catalogSearchRequestDTO.SearchStr, request.catalogSearchRequestDTO.CategoryId),
                catalogCharacteristicWithProductCharacteristics = await unitOfWork.CatalogRepository.GetProductCharacteristicsByCategoryId(
                    request.catalogSearchRequestDTO.CategoryId),
                categoryWithProductCountDTOs = await unitOfWork.CatalogRepository.GetCategoriesBySearchStr(
                    request.catalogSearchRequestDTO.SearchStr),
                PageNumber = request.catalogSearchRequestDTO.PageNumber,
                PageSize = request.catalogSearchRequestDTO.PageSize,
                MinPrice = productPaginationDto.MinPrice,
                MaxPrice = productPaginationDto.MaxPrice,
                TotalCount = productPaginationDto.TotalCount,
            };
            
            return Result.Ok(result);
        }
    }
}
