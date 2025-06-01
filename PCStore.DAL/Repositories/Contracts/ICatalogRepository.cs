using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.DTOs.CategoryDTOs;
using PCStore.Data.DTOs.OtherDTOs.CatalogDTOs;
using PCStore.Data.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.DAL.Repositories.Contracts
{
    public interface ICatalogRepository
    {
        Task<PaginationProductsDTO> GetCatalogProductPagination(CatalogSearchRequestDTO catalogSearchRequestDTO);
        Task<List<GetBrandDTO>> GetBrandsBySearchStrAndCategoryId(string searchStr, int categoryId);
        Task<List<CategoryWithProductCountDTO>> GetCategoriesBySearchStr(string searchStr);
        Task<List<CatalogCharacteristicWithProductCharacteristicDTO>> GetProductCharacteristicsByCategoryId(int categoryId);
    }
}
