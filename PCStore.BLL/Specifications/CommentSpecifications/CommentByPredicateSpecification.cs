using PCStore.DAL.Specification;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Specifications.CommentSpecifications
{
    public class CommentByPredicateSpecification : BaseSpecification<Comment, Comment>
    {
        public CommentByPredicateSpecification(List<int> ints) : base(x => ints.Contains(x.Id))
        {
            
        }
    }
}
