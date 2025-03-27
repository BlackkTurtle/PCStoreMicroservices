using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string FullName { get; set; }=null!;
        public int ProductId { get; set; }
        public int? ParentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DateModified { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public Comment? Parent { get; set; }
        public ICollection<Comment>? Children { get; set; }
    }
}
