using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCStoreService.API.DTOs;

public partial class CommentDTO
{
    public int CommentId { get; set; }

    public int Article { get; set; }
    [Range(1, 5, ErrorMessage = "Stars should be betwenn 1 and 5")]
    public int Stars { get; set; }

    public DateTime? CommentDate { get; set; }

    public string UserId { get; set; } = null!;

    public string? Comment1 { get; set; }
}
