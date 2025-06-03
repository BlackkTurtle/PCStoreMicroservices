using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.CommentDTOs
{
    public class CreateCommentDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
