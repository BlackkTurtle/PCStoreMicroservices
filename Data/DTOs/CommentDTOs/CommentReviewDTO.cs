using PCStore.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.CommentDTOs
{
    public class CommentReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ProductId { get; set; }
    }
}
