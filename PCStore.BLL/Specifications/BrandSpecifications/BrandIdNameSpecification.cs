using PCStore.DAL.Specification;
using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Specifications.BrandSpecifications
{
    public class BrandIdNameSpecification : BaseSpecification<Brand, GetBrandDTO>
    {
        public BrandIdNameSpecification(string nameLike) : base(x => x.Name.ToLower().Contains(nameLike.ToLower()))
        {
            ApplyPaging(0, 2);
            ApplySelector(x => new GetBrandDTO
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
    }
}
