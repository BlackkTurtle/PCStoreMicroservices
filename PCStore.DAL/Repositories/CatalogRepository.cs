using FluentResults;
using Microsoft.EntityFrameworkCore;
using PCStore.DAL.Caching.RedisCache;
using PCStore.DAL.Persistence;
using PCStore.DAL.Repositories.Contracts;
using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.DTOs.CategoryDTOs;
using PCStore.Data.DTOs.OtherDTOs.CatalogDTOs;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IRedisCacheService redisCacheService;
        public CatalogRepository(AppDbContext appDbContext, IRedisCacheService redisCacheService)
        {
            this.appDbContext = appDbContext;
            this.redisCacheService = redisCacheService;
        }

        public async Task<List<GetBrandDTO>> GetBrandsBySearchStrAndCategoryId(string searchStr, int categoryId)
        {
            if (categoryId == 0)
            {
                var result = await appDbContext.Products.Where(x => x.Name.ToLower().Contains(searchStr.ToLower()))
                    .Select(x => x.Brand)
                    .Distinct()
                    .Select(x => new GetBrandDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                    })
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                return result;
            }
            else
            {
                var result = await appDbContext.Products.Where(x => x.Name.ToLower().Contains(searchStr.ToLower()) && x.CategoryId == categoryId)
                    .Select(x => x.Brand)
                    .Distinct()
                    .Select(x => new GetBrandDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                    })
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                return result;
            }
        }

        public async Task<PaginationProductsDTO> GetCatalogProductPagination(CatalogSearchRequestDTO catalogSearchRequestDTO)
        {
            IQueryable<Product> productsQuery = appDbContext.Products;

            productsQuery = productsQuery.Where(x => x.Name.ToLower().Contains(catalogSearchRequestDTO.SearchStr.ToLower()));

            if (catalogSearchRequestDTO.BrandIds.Any())
            {
                productsQuery = productsQuery.Where(x => catalogSearchRequestDTO.BrandIds.Contains(x.BrandId));
            }

            if (catalogSearchRequestDTO.CategoryId!= 0)
            {
                productsQuery = productsQuery.Where(x => x.CategoryId == catalogSearchRequestDTO.CategoryId);
            }

            if (catalogSearchRequestDTO.MaxPrice != 0) 
            {
                productsQuery = productsQuery.Where(x => x.Price >= catalogSearchRequestDTO.MinPrice && x.Price <= catalogSearchRequestDTO.MaxPrice);
            }

            if (catalogSearchRequestDTO.CatalogCharacteristicWithProductCharacteristics.Any())
            {
                foreach (var characteristic in catalogSearchRequestDTO.CatalogCharacteristicWithProductCharacteristics) 
                {
                    var charId = characteristic.CharacteristicId;
                    var names = characteristic.ProductCharacteristicNames;
                    productsQuery = productsQuery.Where(x =>
                    x.ProductCharacteristics.Any(pc => pc.CharacteristicId == charId && names.Contains(pc.Name)));
                }
            }

            if (catalogSearchRequestDTO.SortMethod == 0)
            {
                productsQuery = productsQuery.OrderBy(x => x.Price);
            }
            else if (catalogSearchRequestDTO.SortMethod == 1)
            {
                productsQuery = productsQuery.OrderByDescending(x => x.Price);
            }
            else if (catalogSearchRequestDTO.SortMethod == 2)
            {
                productsQuery = productsQuery.OrderBy(x => x.Name);
            }
            else if (catalogSearchRequestDTO.SortMethod == 3)
            {
                productsQuery = productsQuery.OrderByDescending(x => x.Name);
            }

            var totalCount = await productsQuery.CountAsync();

            var result = new PaginationProductsDTO()
            {
                Products = await productsQuery.Skip((catalogSearchRequestDTO.PageNumber - 1) * catalogSearchRequestDTO.PageSize)
                .Take(catalogSearchRequestDTO.PageSize)
                .Select(x => new GetProductWithRatingDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Rating = x.Comments.Average(x => (double?)x.Rating) ?? 0.0,
                    Availlability = x.ProductStorages.Sum(ps => ps.Quantity) > 0,
                    PhotoLink = x.Photos.FirstOrDefault().PhotoLink,
                    Price = x.Price,
                }).ToListAsync(),
                TotalCount = totalCount,
                PageSize = catalogSearchRequestDTO.PageSize,
                PageNumber = catalogSearchRequestDTO.PageNumber,
                MinPrice = totalCount > 0 ? await productsQuery.MinAsync(x => x.Price) : 0,
                MaxPrice = totalCount > 0 ? await productsQuery.MaxAsync(x => x.Price) : 0,
            };

            return result;
        }

        public async Task<List<CategoryWithProductCountDTO>> GetCategoriesBySearchStr(string searchStr)
        {
            var result = await appDbContext.Categories
                .Select(c => new CategoryWithProductCountDTO()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhotoLink = c.PhotoLink,
                    ProductsCount = c.Products.Count(x => x.Name.ToLower().Contains(searchStr.ToLower()))
                })
                .Where(c => c.ProductsCount > 0)
                .OrderBy(x => x.ProductsCount)
                .ToListAsync();

            return result;
        }

        public async Task<List<CatalogCharacteristicWithProductCharacteristicDTO>> GetProductCharacteristicsByCategoryId(int categoryId)
        {
            if (categoryId == 0)
            {
                return new List<CatalogCharacteristicWithProductCharacteristicDTO>();
            }

            var result = await appDbContext.Categories
                .Where(c => c.Id == categoryId)
                .SelectMany(c => c.Characteristics)
                .Where(ch => ch.ProductCharacteristics.Any(pc => pc.Product.CategoryId == categoryId))
                .Select(ch => new CatalogCharacteristicWithProductCharacteristicDTO
                {
                    CharacteristicId = ch.Id,
                    CharacteristicName = ch.Name,
                    ProductCharacteristicNames = ch.ProductCharacteristics
                    .Where(pc => pc.Product.CategoryId == categoryId)
                    .Select(pc => pc.Name)
                    .Distinct()
                    .OrderBy(v => v)
                    .ToList()
                })
                .ToListAsync();

            return result;
        }
    }
}
