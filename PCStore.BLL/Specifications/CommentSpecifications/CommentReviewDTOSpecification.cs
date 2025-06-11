using PCStore.DAL.Specification;
using PCStore.Data.DTOs.CommentDTOs;
using PCStore.Data.Models;
using PCStore.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Specifications.CommentSpecifications
{
    public class CommentReviewDTOSpecification : BaseSpecification<Comment, CommentReviewDTO>
    {
        public CommentReviewDTOSpecification() : base(x => x.CommentStatus == CommentStatusEnum.Review)
        {
            ApplyOrderBy(x => x.CreatedDate);
            ApplyPaging(0, 12);
            ApplySelector(x => new CommentReviewDTO
            {
                Id = x.Id,
                Content = x.Content,
                ProductId = x.ProductId,
            });
        }
    }
}
