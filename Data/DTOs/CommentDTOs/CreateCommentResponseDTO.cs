using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.CommentDTOs
{
    public class CreateCommentResponseDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
