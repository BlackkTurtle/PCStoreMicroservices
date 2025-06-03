using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.Data.DTOs.CommentDTOs
{
    public class CreateReviewDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1,5,ErrorMessage = "The field must have value from 1 to 5.")]
        public int Rating { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
    }
}
