using PCStore.DAL.Specification;
using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Specifications.ProductSpecifications
{
    public class ProductIdNameSpecification : BaseSpecification<Product, ProductIdNameDTO>
    {
        public ProductIdNameSpecification(string nameLike) : base(x => x.Name.ToLower().Contains(nameLike.ToLower()))
        {
            ApplyPaging(0, 3);
            ApplySelector(x => new ProductIdNameDTO
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
    }
}
