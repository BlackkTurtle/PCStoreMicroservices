using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataAccess.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int Article { get; set; }
    public int Stars { get; set; }

    public DateTime? CommentDate { get; set; }

    public string UserId { get; set; } = null!;

    public string? Comment1 { get; set; }
    [JsonIgnore]

    public virtual Product ArticleNavigation { get; set; } = null!;
}
