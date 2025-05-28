using PCStore.DAL.Specification;
using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.DTOs.CategoryDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Specifications.CategorySpecifications
{
    public class CategoryIdNameSpecification : BaseSpecification<Category, CategoryIdNameDTO>
    {
        public CategoryIdNameSpecification(string nameLike) : base(x => x.Name.ToLower().Contains(nameLike.ToLower()))
        {
            ApplyPaging(0, 2);
            ApplySelector(x => new CategoryIdNameDTO
            {
                Id = x.Id,
                Name = x.Name,
            });
        }
    }
}
