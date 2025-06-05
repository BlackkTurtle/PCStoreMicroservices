using PCStore.DAL.Specification;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Specifications.CommentSpecifications
{
    public class CommentWithCommentsSpecification : BaseSpecification<Comment, Comment>
    {
        public CommentWithCommentsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Children);
        }
    }
}
